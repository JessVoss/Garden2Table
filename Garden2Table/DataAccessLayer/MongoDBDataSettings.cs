using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden2Table.DataAccessLayer
{
    public static class MongoDBDataSettings
    {
        private static string userName = "Admin";
        private static string password = "Jv212345";

        public static string connectionString = $"mongodb+srv://{userName}:{password}>@cluster0.vaige.mongodb.net/{databaseName}?retryWrites=true&w=majority";

        public static string collectionName = "Jess CIT255";
        public static string databaseName = "Garden2Table";
    }
}
