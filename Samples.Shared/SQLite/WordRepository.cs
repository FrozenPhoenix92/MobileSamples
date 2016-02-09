using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net;

namespace Samples.Shared.SQLite
{
    public class WordRepository : IRepository<Word>, IDisposable
    {
        private readonly SQLiteConnection _connection;
        private object _locker = new object();


        public WordRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }


        public IEnumerable<Word> GetAll()
        {
            lock (_locker)
            {
                return _connection.Table<Word>().ToList();
            }
        }

        public Word Get(int id)
        {
            lock (_locker)
            {
                return _connection.Get<Word>(id);
            }
        }

        public int Create(Word word)
        {
            lock (_locker)
            {
                if (GetAll().Any(elem => elem.Id == word.Id))
                    throw new Exception("Элемент с таким идентификатором уже существует.");
                return _connection.Insert(word);
            }
        }

        public int Update(Word word)
        {
            lock (_locker)
            {
                if (GetAll().All(elem => elem.Id != word.Id))
                    throw new Exception("Элемент с таким идентификатором не существует.");
                return _connection.Update(word);
            }
        }

        public int Delete(int id)
        {
            lock (_locker)
            {
                return _connection.Delete<Word>(id);
            }
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
