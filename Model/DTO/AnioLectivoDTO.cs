using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class AnioLectivoDTO
    {
        public string Anio { get; set; }
        public int Id { get; set; }
        public AnioLectivoDTO(string anio, int id)
        {
            Anio = anio;
            Id = id;
        }
    }
}
