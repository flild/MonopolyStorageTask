using MonopolyTestTask.Data;
using MonopolyTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyTestTask.Service
{
    internal class BoxService
    {
        ApplicationContext _db;
        public BoxService()
        {
            _db = new ApplicationContext();
        }
        public void CreateBox(Box box)
        {
            _db.Boxes.Add(box);
            _db.SaveChanges();
        }

    }
}
