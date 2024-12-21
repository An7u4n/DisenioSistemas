using Model.DTO;

namespace Services.ReservaService.Interfaces
{
    public interface IValidacionReservaService
    {
        public void Validar<T>(T reserva);
    }
}
