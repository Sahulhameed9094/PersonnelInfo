using Microsoft.AspNetCore.Mvc;
using PersonnelInfo.Data;
using PersonnelInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonnelInfo.Controllers
{
    public class StaffController : Controller
    {
        AppDbContext _context;
        public StaffController(AppDbContext context)
        {
            _context = context;
        }
        //get all staff in the database
        public IActionResult List()
        {
            var staff = _context.Staffs.ToList();
            return View(staff);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int Id)
        {
            var staff = _context.Staffs.FirstOrDefault(e => e.Id == Id);
            return View(staff);
        }

        public IActionResult Delete(int Id)
        {
            //get the staff with the Id
            var staff = _context.Staffs.FirstOrDefault(e => e.Id == Id);
            //remove the staff from the database
            _context.Staffs.Remove(staff);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Post(Staff staff)
        {
            //add staff to the context
            _context.Staffs.Add(staff);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Update(Staff staff)
        {
            //get the existing staff
            var old_staff = _context.Staffs.FirstOrDefault(e => e.Id == staff.Id);
            //update with new staff information
            _context.Entry(old_staff).CurrentValues.SetValues(staff);
            _context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
