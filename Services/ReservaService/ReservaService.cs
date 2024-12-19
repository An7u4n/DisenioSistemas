using Data.DAO;
using Model.Abstract;
using Model.DTO;
using Model.Entity;
using Model.Enums;
using Model.Exceptions;
using Services.AulaService;
namespace Services.ReservaService
{
    public class ReservaService : IReservaService
    {

        private readonly ReservaDAO _reservaDAO;
        private readonly IAulaService _aulaService;
        private readonly AulaDAO _aulaDAO;
        private readonly AnioLectivoDAO _anioLectivoDAO;

        public ReservaService(ReservaDAO reservaDAO, IAulaService aulaService, AulaDAO aulaDAO, AnioLectivoDAO anioLectivoDAO)
        {
            _reservaDAO = reservaDAO;
            _aulaService = aulaService;
            _aulaDAO = aulaDAO;
            _anioLectivoDAO = anioLectivoDAO;
        }

        public List<DisponibilidadAulaDTO> validarReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO)
        {
            validarCamposEsporadica(reservaEsporadicaDTO);

            List<DisponibilidadAulaDTO> aulasDisponibles = _aulaService.obtenerAulasEsporadica(reservaEsporadicaDTO);

            // Filtrar las 3 aulas con mayor capacidad por cada día
            List<DisponibilidadAulaDTO> aulasConMayorCapacidad = aulasDisponibles.Select(disponibilidad =>
            {
                disponibilidad.AulasDisponibles = disponibilidad.AulasDisponibles
                    .OrderByDescending(aula => aula.capacidad)
                    .Take(3)
                    .ToList();
                return disponibilidad;
            }).ToList();

            List<List<SuperposicionInfoDTO>> superposiciones = new List<List<SuperposicionInfoDTO>>();

            foreach (DisponibilidadAulaDTO disponibilidad in aulasDisponibles)
            {
                if (disponibilidad.AulasDisponibles.Count == 0)
                {
                    superposiciones.Add(disponibilidad.SuperposicionesMinimas);
                }
            }

            if(superposiciones.Count > 0) throw new SuperposicionDeAulasException(superposiciones);

            return aulasConMayorCapacidad;
        }
        public void validarCamposEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO)
        {
            if (reservaEsporadicaDTO == null)
            {
                throw new Exception("La reserva no puede ser nula.");
            }

            List<string> errores = new List<string>();

            // Validar campos principales de ReservaEsporadicaDTO
            if (string.IsNullOrEmpty(reservaEsporadicaDTO.profesor))
                errores.Add("El campo 'profesor' es requerido.");

            if (string.IsNullOrEmpty(reservaEsporadicaDTO.nombreCatedra))
                errores.Add("El campo 'nombreCatedra' es requerido.");

            if (string.IsNullOrEmpty(reservaEsporadicaDTO.correoElectronico))
                errores.Add("El campo 'correoElectronico' es requerido.");

            if (reservaEsporadicaDTO.cantidadAlumnos <= 0)
                errores.Add("El campo 'cantidadAlumnos' debe ser mayor a 0.");

            if (reservaEsporadicaDTO.dias == null || reservaEsporadicaDTO.dias.Count == 0)
                errores.Add("La lista de 'dias' no puede estar vacía.");

            // Validar días dentro de la reserva
            if (reservaEsporadicaDTO.dias != null)
            {
                foreach (var dia in reservaEsporadicaDTO.dias)
                {
                    if (dia.fecha == default)
                        errores.Add($"El campo 'fecha' es inválido o no se ingresó para un día.");

                    if (string.IsNullOrEmpty(dia.horaInicio))
                        errores.Add($"El campo 'horaInicio' es requerido para la fecha {dia.fecha:yyyy-MM-dd}.");

                    if (dia.duracionMinutos <= 0)
                        errores.Add($"El campo 'duracionMinutos' debe ser mayor a 0 para la fecha {dia.fecha:yyyy-MM-dd}.");

                    if (dia.duracionMinutos % 30 != 0)
                        errores.Add($"El campo 'duracionMinutos' debe ser múltiplo de 30 para la fecha {dia.fecha:yyyy-MM-dd}.");

                    if (dia.fecha.Date <= DateTime.Now.Date)
                        errores.Add($"La 'fecha' debe ser posterior a la actual para el día {dia.fecha:yyyy-MM-dd}.");
                }
            }

            // Validar fechas duplicadas
            var fechasDuplicadas = reservaEsporadicaDTO.dias?
                .GroupBy(d => d.fecha.Date)
                .Where(g => g.Count() > 1)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(d => $"{d.horaInicio} ({d.duracionMinutos} minutos)").ToList()
                );

            if (fechasDuplicadas != null && fechasDuplicadas.Any())
            {
                foreach (var fecha in fechasDuplicadas)
                {
                    errores.Add($"Fecha duplicada: {fecha.Key:yyyy-MM-dd} con horarios {string.Join(", ", fecha.Value)}.");
                }
            }

            // Lanzar excepción con los errores encontrados
            if (errores.Any())
            {
                throw new Exception($"Errores de validación:\n{string.Join("\n", errores)}");
            }

        }
        public void ConfirmarDisponibilidadAulaParaReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO)
        {
            validarCamposEsporadica(reservaEsporadicaDTO);

            var existenciaSuperposicion = new List<SuperposicionInfoDTO>();

            foreach (var diaEnReserva in reservaEsporadicaDTO.dias)
            {
                var aula = _aulaDAO.ObtenerAulaPorNumero((int)diaEnReserva.numeroAula);

                existenciaSuperposicion.AddRange(_aulaService.CalcularSuperposicion(diaEnReserva.fecha,
                    TimeOnly.Parse(diaEnReserva.horaInicio),
                    TimeOnly.Parse(diaEnReserva.horaInicio).AddMinutes(diaEnReserva.duracionMinutos),
                    aula));
            }
            if(existenciaSuperposicion.Count > 0)
            {
                throw new SuperposicionDeAulasException();
            }
        }

        public void validarCamposPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO)
        {
            if (reservaPeriodicaDTO == null)
            {
                throw new Exception("La reserva no puede ser nula.");
            }

            List<string> errores = new List<string>();

            // Validar campos principales de ReservaPeriodicaDTO
            if (string.IsNullOrEmpty(reservaPeriodicaDTO.profesor))
                errores.Add("El campo 'profesor' es requerido.");

            if (string.IsNullOrEmpty(reservaPeriodicaDTO.nombreCatedra))
                errores.Add("El campo 'nombreCatedra' es requerido.");

            if (string.IsNullOrEmpty(reservaPeriodicaDTO.correoElectronico))
                errores.Add("El campo 'correoElectronico' es requerido.");

            if (reservaPeriodicaDTO.cantidadAlumnos <= 0)
                errores.Add("El campo 'cantidadAlumnos' debe ser mayor a 0.");

            if (string.IsNullOrEmpty(reservaPeriodicaDTO.fechaInicio))
                errores.Add("El campo 'fechaInicio' es requerido.");

            if (string.IsNullOrEmpty(reservaPeriodicaDTO.fechaFin))
                errores.Add("El campo 'fechaFin' es requerido.");

            if (reservaPeriodicaDTO.dias == null || reservaPeriodicaDTO.dias.Count == 0)
                errores.Add("La lista de 'dias' no puede estar vacía.");

            // Validar que fechaInicio sea anterior a fechaFin
            DateTime fechaInicio = default, fechaFin = default;
            if (!string.IsNullOrEmpty(reservaPeriodicaDTO.fechaInicio) && !string.IsNullOrEmpty(reservaPeriodicaDTO.fechaFin))
            {
                if (!DateTime.TryParse(reservaPeriodicaDTO.fechaInicio, out fechaInicio))
                    errores.Add("El campo 'fechaInicio' tiene un formato inválido.");

                if (!DateTime.TryParse(reservaPeriodicaDTO.fechaFin, out fechaFin))
                    errores.Add("El campo 'fechaFin' tiene un formato inválido.");

                if (fechaInicio >= fechaFin)
                    errores.Add("El campo 'fechaInicio' debe ser anterior al campo 'fechaFin'.");

                // Validar que fechaInicio sea posterior a la fecha actual
                if (fechaInicio.Date <= DateTime.Now.Date)
                    errores.Add("El campo 'fechaInicio' debe ser posterior a la fecha actual.");
            }

            // Validar días dentro de la reserva
            if (reservaPeriodicaDTO.dias != null)
            {
                foreach (var dia in reservaPeriodicaDTO.dias)
                {
                    if (string.IsNullOrEmpty(dia.horaInicio))
                        errores.Add($"El campo 'horaInicio' es requerido para el día {dia.diaSemana}.");

                    if (dia.duracionMinutos <= 0)
                        errores.Add($"El campo 'duracionMinutos' debe ser mayor a 0 para el día {dia.diaSemana}.");

                    if (dia.duracionMinutos % 30 != 0)
                        errores.Add($"El campo 'duracionMinutos' debe ser múltiplo de 30 para el día {dia.diaSemana}.");
                }
            }

            // Validar días duplicados en la semana
            var diasDuplicados = reservaPeriodicaDTO.dias?
                .GroupBy(d => d.diaSemana)
                .Where(g => g.Count() > 1)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(d => $"{d.horaInicio} ({d.duracionMinutos} minutos)").ToList()
                );

            if (diasDuplicados != null && diasDuplicados.Any())
            {
                foreach (var dia in diasDuplicados)
                {
                    errores.Add($"Día de la semana duplicado: {dia.Key} con horarios {string.Join(", ", dia.Value)}.");
                }
            }
            // Lanzar excepción con los errores encontrados
            if (errores.Any())
            {
                throw new Exception($"Errores de validación:\n{string.Join("\n", errores)}");
            }
        }

        public void ConfirmarDisponibilidadAulaParaReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO)
        {
            validarCamposPeriodica(reservaPeriodicaDTO);
            var existenciaSuperposicion = new List<SuperposicionInfoDTO>();

            foreach (var diaEnReserva in reservaPeriodicaDTO.dias)
            {
                var aula = _aulaDAO.ObtenerAulaPorNumero((int)diaEnReserva.numeroAula);
                
                existenciaSuperposicion.AddRange(_aulaService.CalcularSuperposicionPeriodica(diaEnReserva.diaSemana,
                    TimeOnly.Parse(diaEnReserva.horaInicio), 
                    TimeOnly.Parse(diaEnReserva.horaInicio).AddMinutes(diaEnReserva.duracionMinutos), 
                    aula, DateOnly.Parse(reservaPeriodicaDTO.fechaInicio), DateOnly.Parse(reservaPeriodicaDTO.fechaFin)));
            }

            if (existenciaSuperposicion.Count > 0)
            {
                throw new SuperposicionDeAulasException();
            }
        }

        public List<DisponibilidadAulaDTO> validarReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO)
        {
           validarCamposPeriodica(reservaPeriodicaDTO);

            // Obtener la disponibilidad de aulas para la reserva periódica
            List<DisponibilidadAulaDTO> aulasDisponibles = _aulaService.obtenerAulasPeriodica(reservaPeriodicaDTO);

            // Filtrar las 3 aulas con mayor capacidad por cada día
            List<DisponibilidadAulaDTO> aulasConMayorCapacidad = aulasDisponibles.Select(disponibilidad =>
            {
                disponibilidad.AulasDisponibles = disponibilidad.AulasDisponibles
                    .OrderByDescending(aula => aula.capacidad)
                    .Take(3)
                    .ToList();
                return disponibilidad;
            }).ToList();

            // Verificar si hay días sin aulas disponibles y recopilar superposiciones
            List<List<SuperposicionInfoDTO>> superposiciones = new List<List<SuperposicionInfoDTO>>();
            foreach (DisponibilidadAulaDTO disponibilidad in aulasConMayorCapacidad)
            {
                if (disponibilidad.AulasDisponibles.Count == 0)
                {
                    superposiciones.Add(disponibilidad.SuperposicionesMinimas);
                }
            }


            if (superposiciones.Count > 0) throw new SuperposicionDeAulasException(superposiciones);

            return aulasConMayorCapacidad;

        }

        public ReservaEsporadica convertirDTOAReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO)
        {
            var reservaEsporadica = new ReservaEsporadica();
            reservaEsporadica.setId(reservaEsporadicaDTO.idReserva);
            reservaEsporadica.setProfesor(reservaEsporadicaDTO.profesor);
            reservaEsporadica.setNombreCatedra(reservaEsporadicaDTO.nombreCatedra);
            reservaEsporadica.setCorreoElectronico(reservaEsporadicaDTO.correoElectronico);
            reservaEsporadica.idBedel = reservaEsporadicaDTO.idBedel;
            return reservaEsporadica;
        }
        public List<DiaEsporadica> convertirDiasEsporadicoDTOaEntidad(ICollection<DiaEsporadicaDTO> diasDTO)
        {
            var dias = new List<DiaEsporadica>();
            foreach (var dia in diasDTO)
            {
                if (dia.numeroAula == null) throw new ArgumentNullException("No se especifica aula");
                var aula = _aulaDAO.ObtenerAulaPorNumero((int)dia.numeroAula);
                var diaEsporadica = new DiaEsporadica(dia, aula);
                dias.Add(diaEsporadica);
            }
            return dias;
        }

        public void guardarReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO)
        {
            var reservaEsporadica = convertirDTOAReservaEsporadica(reservaEsporadicaDTO);

            var dias = convertirDiasEsporadicoDTOaEntidad(reservaEsporadicaDTO.dias);

            reservaEsporadica.DiasEsporadica = dias;

            // Guardar en la base de datos
            _reservaDAO.guardarReserva(reservaEsporadica);
        }

        public ReservaPeriodica convertirDTOAReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO, List<DiaPeriodica> dias)
        {
            // Crear instancia de ReservaPeriodica y asignar propiedades
            var reservaPeriodica = new ReservaPeriodica();
           
            reservaPeriodica.setId(reservaPeriodicaDTO.idReserva);
            reservaPeriodica.setProfesor(reservaPeriodicaDTO.profesor);
            reservaPeriodica.setNombreCatedra(reservaPeriodicaDTO.nombreCatedra);
            reservaPeriodica.setCorreoElectronico(reservaPeriodicaDTO.correoElectronico);
            reservaPeriodica.idBedel = reservaPeriodicaDTO.idBedel;
            reservaPeriodica.setFechaInicio(DateTime.Parse(reservaPeriodicaDTO.fechaInicio));
            reservaPeriodica.setFechaFin(DateTime.Parse(reservaPeriodicaDTO.fechaFin));
            reservaPeriodica.setTipoPeriodo(reservaPeriodicaDTO.tipoPeriodo);

            reservaPeriodica.Cuatrimestres = new List<Cuatrimestre>();

            reservaPeriodica.DiasPeriodica = dias;

            var anio = DateOnly.Parse(reservaPeriodicaDTO.fechaInicio).Year;
            var anioLectivo = _anioLectivoDAO.GetAnioLectivo(anio.ToString());
            
            if (reservaPeriodica.getTipoPeriodo() == TipoPeriodo.anual)
            {
                reservaPeriodica.Cuatrimestres = anioLectivo.Cuatrimestres;
            }
            else if (reservaPeriodica.getTipoPeriodo() == TipoPeriodo.cuatrimestral)
            {
                if (reservaPeriodicaDTO.numeroCuatrimestre == 1)
                {
                    reservaPeriodica.Cuatrimestres.Add(anioLectivo.Cuatrimestres.First(c => c.getNumeroCuatrimestre() == 1));
                }
                else if (reservaPeriodicaDTO.numeroCuatrimestre == 2)
                {
                    var cuatri = anioLectivo.Cuatrimestres.First(c => c.getNumeroCuatrimestre() == 2);
                    reservaPeriodica.Cuatrimestres.Add(cuatri);
                }
            }

            return reservaPeriodica;
        }

        public List<DiaPeriodica> convertirDiasPeriodicaDTOaEntidad(ICollection<DiaPeriodicaDTO> diasDTO)
        {
            var dias = new List<DiaPeriodica>();

            foreach (var dia in diasDTO)
            {
                if (dia.numeroAula == null) throw new ArgumentNullException("No se especifica aula");
                var aula = _aulaDAO.ObtenerAulaPorNumero((int)dia.numeroAula);
                var diaPeriodica = new DiaPeriodica(dia, aula);
                dias.Add(diaPeriodica);
            }
            return dias;
        }

        public void guardarReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO)
        {
            // Crear instancia de ReservaPeriodica y asignar propiedades

            var dias = convertirDiasPeriodicaDTOaEntidad(reservaPeriodicaDTO.dias);


            var reservaPeriodica = convertirDTOAReservaPeriodica(reservaPeriodicaDTO, dias);

            _reservaDAO.guardarReserva(reservaPeriodica);
        }
    }
}