using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net;

namespace Samples.Shared.SQLite
{
    public class SectionRepository : IRepository<Section>, IDisposable
    {
        private readonly SQLiteConnection _connection;
        private object _locker = new object();


        public SectionRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }


        public IEnumerable<Section> GetAll()
        {
            lock (_locker)
            {
                return _connection.Table<Section>().ToList();
            }
        }

        public Section Get(int id)
        {
            lock (_locker)
            {
                return _connection.Get<Section>(id);
            }
        }

        public int Create(Section section)
        {
            lock (_locker)
            {
                if (GetAll().Any(elem => elem.Id == section.Id))
                    throw new Exception("Элемент с таким идентификатором уже существует.");
                return _connection.Insert(section);
            }
        }

        public int Update(Section section)
        {
            lock (_locker)
            {
                if (GetAll().All(elem => elem.Id != section.Id))
                    throw new Exception("Элемент с таким идентификатором не существует.");
                return _connection.Update(section);
            }
        }

        public int Delete(int id)
        {
            lock (_locker)
            {
                return _connection.Delete<Section>(id);
            }
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
