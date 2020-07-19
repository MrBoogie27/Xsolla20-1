using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace PaymentSystem.Models
{
    public class DbHelper
    {
        // открывает базу данных, если ее нет - то создает
        LiteDatabase db;
        ILiteCollection<Session> collection;
        public DbHelper()
        {
            db = new LiteDatabase(@"Payments.db");
            collection = db.GetCollection<Session>("sessions");
            collection.EnsureIndex(x => x.Session_id);
        }

        public void AddSession(Session session)
        {
            collection.Insert(session);
        }

        public Session GetSession(string session_id)
        {
            return collection.Find(session => session.Session_id.Equals(session_id)).FirstOrDefault();
        }

        public void DeleteSession(string session_id)
        {
            collection.Delete(session_id);
        }
    }
}
