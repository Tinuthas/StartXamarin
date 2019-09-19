using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06_Fiap.Web.AspNet.Models
{
    public class CorridaAtleta
    {
        public Corrida Corrida { get; set; }
        public int CorridaId { get; set; }
        public Atleta Atleta { get; set; }
        public int AtletaId { get; set; }
    }
}
