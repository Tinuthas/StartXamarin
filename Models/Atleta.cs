using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06_Fiap.Web.AspNet.Models
{
    public class Atleta
    {
        public int AtletaID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Profissional { get; set; }

        //Relacionamentos
        public IList<CorridaAtleta> CorridaAtletas { get; set; }

    }
}
