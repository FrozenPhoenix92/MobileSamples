using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net;

namespace Samples.Shared.SQLite
{
    public class UnitOfWork
    {
        public UnitOfWork(global::SQLite.Net.Interop.ISQLitePlatform platform, string pathToDatabase)
        {
            var connection = new SQLiteConnection(platform, pathToDatabase);
            CreateTables(connection);

            Words = new WordRepository(connection);
            Sections = new SectionRepository(connection);
        }

        public IRepository<Word> Words { get; set; }
        public IRepository<Section> Sections { get; set; }

        private static void CreateTables(SQLiteConnection connection)
        {
            CreateWordsTable(connection);
            CreateSectionTable(connection);
        }

        private static void CreateWordsTable(SQLiteConnection connection)
        {
            connection.CreateTable<Word>();
        }

        private static void CreateSectionTable(SQLiteConnection connection)
        {
            connection.CreateTable<Section>();
        }
    }
}
