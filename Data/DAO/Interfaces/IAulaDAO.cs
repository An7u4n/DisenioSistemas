using Model.Abstract;

namespace Data.DAO.Interfaces
{
    public interface IAulaDAO
    {
        HashSet<Aula> getAulasByTipo(Type tipoAula);
        HashSet<Aula> getAulasByTipo<T>() where T : Aula;
        void GuardarAula(Aula aula);
        Aula ObtenerAula(int numeroAula);
        Aula ObtenerAulaPorNumero(int numeroAula);
        ICollection<Aula> ObtenerAulas();
    }
}