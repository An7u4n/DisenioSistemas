using Data.DAO;
using Model.Abstract;
using Model.DTO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ReservaService
{
    public class ReservaService : IReservaService
    {

        ReservaDAO _reservaDAO;

        public ReservaService(ReservaDAO reservaDAO)
        {
            _reservaDAO = reservaDAO;
        }
        public ReservaEsporadicaDTO GuardarReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO)
        {
            
            throw new NotImplementedException();
        }

        public ReservaPeriodicaDTO GuardarReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO)
        {
            //en desarrollo
            throw new NotImplementedException();
        }

        
        public ReservaDTO reservarAulas(ReservaDTO reservaDTO, List<DiaDTO> diaDTOs)
        {
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
        }

        private List<Dia> crearDias(Type type, List<DiaDTO> diaDTOs)
        {
            List<Dia> dias = new List<Dia>();
            foreach (DiaDTO diaDto in diaDTOs)
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
        }
    }
}
