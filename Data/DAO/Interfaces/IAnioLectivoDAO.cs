using Model.Entity;

namespace Data.DAO.Interfaces
{
    public interface IAnioLectivoDAO
    {
        AnioLectivo GetAnioLectivo(string anio);
        void GuardarAnioLectivo(string anioLectivo);
    }
}