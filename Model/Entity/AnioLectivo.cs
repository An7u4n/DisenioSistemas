using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class AnioLectivo
    {
        [Key] private int IdAnioLectivo;
        private string Anio;

        public AnioLectivo() { }
        public AnioLectivo(string anio) 
        {
            Anio = anio;
        }

        public int GetIdAnioLectivo() => IdAnioLectivo;
        public string GetAnio() => Anio;
    }
}
