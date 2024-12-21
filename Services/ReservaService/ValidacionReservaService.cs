using Model.DTO;
using Services.ReservaService.Interfaces;

namespace Services.ReservaService
{
    public class ValidacionReservaService : IValidacionReservaService
    {
        private readonly Dictionary<Type, object> _validators;

        public ValidacionReservaService(Dictionary<Type, object> validators)
        {
            _validators = validators;
        }

        public void Validar<T>(T reservaDTO)
        {
            if (_validators.TryGetValue(typeof(T), out var validator))
            {
                ((IValidarReserva<T>)validator).ValidarReserva(reservaDTO);
            }
            else
            {
                throw new Exception($"No se encontró un validador para el tipo {typeof(T).Name}");
            }
        }
    }
}
