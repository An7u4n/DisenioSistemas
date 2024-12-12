using Data.DAO;
using Model.Abstract;
using Model.DTO;
using Model.Entity;
using Services.AulaService;
namespace Services.ReservaService
{
    public class ReservaService : IReservaService
    {

        private readonly ReservaDAO _reservaDAO;
        private readonly IAulaService _aulaService;
        private readonly AulaDAO _aulaDAO;

        public ReservaService(ReservaDAO reservaDAO, IAulaService aulaService, AulaDAO aulaDAO)
        {
            _reservaDAO = reservaDAO;
            _aulaService = aulaService;
            _aulaDAO = aulaDAO;
        }

        public List<List<AulaDTO>> ObtenerAulasParaReserva(ReservaEsporadicaDTO reservaEsporadicaDTO)
        {
            return _aulaService.obtenerAulasDisponibles(reservaEsporadicaDTO);
        }

        public ReservaPeriodicaDTO GuardarReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO)
        {
            //en desarrollo
            throw new NotImplementedException();
        }

        
        public ReservaDTO reservarAulas(ReservaDTO reservaDTO, List<DiaPeriodicaDTO> diaDTOs)
        {
            /*
            Reserva reserva;

            if (reservaDTO is ReservaEsporadicaDTO esporadicaDTO)
            {
         
                reserva = new ReservaEsporadica(esporadicaDTO);
            }
            else if (reservaDTO is ReservaPeriodicaDTO periodicaDTO)
            {
                
                reserva = new ReservaPeriodica(periodicaDTO);
            }
            else
            {
                throw new ArgumentException("Tipo de reservaDTO no reconocido.");
            }

            List<Dia> dias = crearDias(reserva.GetType(),diaDTOs);


            reserva.Dias = dias;

            reserva = _reservaDAO.guardarReserva(reserva);

            reservaDTO.idReserva = reserva.getId();

            return reservaDTO;
            */
            throw new NotImplementedException();
        }

        /*private List<Dia> crearDias(Type type, List<DiaPeriodicaDTO> diaDTOs)
        {
            List<Dia> dias = new List<Dia>();
            foreach (DiaPeriodicaDTO diaDto in diaDTOs)
            {
                Dia dia;
                if(type == typeof(ReservaEsporadica))
                {
                    dia = new DiaEsporadica(diaDto);
                }
                else if(type == typeof(ReservaPeriodica))
                {
                    dia = new DiaPeriodica(diaDto);
                }
                else
                {
                    throw new NotSupportedException($"Tipo de reserva no soportado: {type.Name}");
                }

                dias.Add(dia);
                
            }
            return dias;
        }*/

        public void GuardarReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO)
        {
            try
            {
                var numeroAula = reservaEsporadicaDTO.dias.First().numeroAula;
                if (numeroAula == null) throw new Exception("No se especifica aula");
                var aula = _aulaDAO.ObtenerAula((int)numeroAula);
            
                var diaReserva = new DiaEsporadica(reservaEsporadicaDTO.dias.First(), aula);
                var reserva = new ReservaEsporadica(reservaEsporadicaDTO);
                reserva.DiaEsporadica = diaReserva;
                reserva.idBedel = 1;
                _reservaDAO.guardarReserva(reserva);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
