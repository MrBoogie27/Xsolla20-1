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
        ILiteCollection<Session> col;
        DbHelper() {
            db = new LiteDatabase(@"Payments.db");
            col = db.GetCollection<Session>("sessions");
            col.EnsureIndex(x => x.Session_id);
        }

        public void AddSession(Session session)
        {
            col.Insert(session);
        }

        public Session GetSession(string session_id)
        {
            return col.Find(session => session.Session_id.Equals(session_id)).FirstOrDefault();
        }

        public void DeleteSession(string session_id)
        {
            col.Delete(session_id);
        }
    }
}
