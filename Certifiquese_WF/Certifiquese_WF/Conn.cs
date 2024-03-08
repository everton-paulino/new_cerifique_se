using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certifiquese_WF
{
    public static class Conn
    {
        public static readonly string Server = "mongodb://localhost:27017";
        public static readonly string Db ="CertifiqueSe";
        public static readonly string CollectionListas = "listas";

        public static IMongoCollection<Listas> AbrirColecaoListas()
        {
            var cli = new MongoClient(Conn.Server);
            var db = cli.GetDatabase(Conn.Db);
            return db.GetCollection<Listas>(Conn.CollectionListas);
        }
    }
}
