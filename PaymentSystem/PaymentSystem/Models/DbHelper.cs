using System.Linq;
using LiteDB;

namespace PaymentSystem.Models
{
    public class DbHelper
    {
        private readonly ILiteCollection<Session> _collection;
        public DbHelper()
        {
            // открывает базу данных, если ее нет - то создает
            var db = new LiteDatabase(@"Payments.db");
            _collection = db.GetCollection<Session>("sessions");
            _collection.EnsureIndex(x => x.SessionId);
        }

        public void AddSession(Session session)
        {
            _collection.Insert(session);
        }

        public Session GetSession(string sessionId)
        {
            return _collection.Find(session => session.SessionId.Equals(sessionId)).FirstOrDefault();
        }

        public void DeleteSession(string sessionId)
        {
            _collection.Delete(sessionId);
        }
    }
}
