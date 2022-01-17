using cruddockercompose.DbEntities;
using cruddockercompose.DbEntities.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cruddockercompose.Controllers
{
    public class UserController : Controller
    {
        private CrudDbContext db;
        public UserController(CrudDbContext _db)
        {
            this.db = _db;
        }
        public IActionResult Index()
        {
            return View(db.User.ToList());
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(User customer)
        {
            db.User.Add(customer);
            db.SaveChanges();
            return View();
        }

        public IActionResult Edit(string Id)
        {
            Guid NewDataId = Guid.Parse(Id);

            User data = new User();

            var customer = db.User.Where(a => a.Id == NewDataId).FirstOrDefault();

            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(User customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }

        public IActionResult Delete(string Id)
        {
            Guid NewDataId = Guid.Parse(Id);

            var customer = db.User.Where(a => a.Id == NewDataId).FirstOrDefault();

            db.User.Remove(customer);

            db.SaveChanges();

            return View();
        }

    }
}
