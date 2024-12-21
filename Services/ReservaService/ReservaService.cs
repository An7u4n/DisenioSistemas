using Data.DAO;
using Data.DAO.Interfaces;
using Model.Abstract;
using Model.DTO;
using Model.Entity;
using Model.Enums;
using Model.Exceptions;
using Services.AulaService;
using Services.ReservaService.Interfaces;
namespace Services.ReservaService
{
    public class ReservaService : IReservaService
    {

        private readonly IReservaDAO _reservaDAO;
        private readonly IAulaService _aulaService;
        private readonly IAulaDAO _aulaDAO;
        private readonly IAnioLectivoDAO _anioLectivoDAO;
        private readonly IValidacionReservaService _validacionReservaService;

        public ReservaService(IReservaDAO reservaDAO, IAulaService aulaService, IAulaDAO aulaDAO, IAnioLectivoDAO anioLectivoDAO, IValidacionReservaService validacionReservaService)
        {
            _reservaDAO = reservaDAO;
            _aulaService = aulaService;
            _aulaDAO = aulaDAO;
            _anioLectivoDAO = anioLectivoDAO;
            _validacionReservaService = validacionReservaService;
        }

        public List<DisponibilidadAulaDTO> validarReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO)
        {
            _validacionReservaService.Validar(reservaEsporadicaDTO);

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
        
        public void ConfirmarDisponibilidadAulaParaReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO)
        {
            _validacionReservaService.Validar(reservaEsporadicaDTO);

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

        public void ConfirmarDisponibilidadAulaParaReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO)
        {
            _validacionReservaService.Validar(reservaPeriodicaDTO);
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
           _validacionReservaService.Validar(reservaPeriodicaDTO);

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