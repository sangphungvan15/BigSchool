using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class LecturerController : Controller
    {
        // GET: Lecturer
        public ActionResult Index()
        {
            return View();
        }
        private readonly ApplicationDbContext _dbContext;

        public LecturerController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Lecturer
        [Authorize]
        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();
            var lecturers = _dbContext.Followings
                .Where(a => a.FollowerId == userId)
                .Select(a => a.Followee)
                .ToList();

            return View(lecturers);


        }
    }
}