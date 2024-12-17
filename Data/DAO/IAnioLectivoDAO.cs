using Model.Entity;

namespace Data.DAO
{
    public interface IAnioLectivoDAO
    {
        AnioLectivo GetAnioLectivo(string anio);
        void GuardarAnioLectivo(string anioLectivo);
    }
}