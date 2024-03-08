using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certifiquese_WF
{
    [BsonIgnoreExtraElements]

    public class Listas
    {   
        public Listas()
        {
            Key = Guid.NewGuid().ToString();
            Registered = DateTime.Now;
            Updated = DateTime.Now;
            IsActive = true;
        }

        public string Key { get; set; }
        public DateTime Registered { get; set; }
        public DateTime Updated { get; set; }
        public bool IsActive { get; set; }
        public string DatadoCurso { get; set; }
        public string NomedoFuncionario { get; set; }
        public string NomedoCurso { get; set; }
        public string NomeInstrutor { get; set; }
        public string LocalidadedoCurso { get; set; }
    }
}
