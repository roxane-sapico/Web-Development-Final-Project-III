using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sapico_Final_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult User()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ShowUser()
        {
            projectEntities fe = new projectEntities();
            var userList = (from a in fe.users
                            select a).ToList();

            ViewData["UserList"] = userList;
            return View();
        }
        public ActionResult Edit(int id)
        {
            projectEntities fe = new projectEntities();
            var userList = (from a in fe.users where a.user_id == id
                            select a).ToList();

            ViewData["User"] = userList;
            return View();
        }
        [HttpPost]
        public ActionResult Update(FormCollection fc )
        {
            String firstname = fc["firstname"]; 
            String lastname = fc["lastname"]; 
            String email = fc["email"]; 
            String password = fc["password"];
            int id = Convert.ToInt16(fc["id"]);
            projectEntities fe = new projectEntities();
            var user = fe.users.Find(id);

            // Update user properties with new values
            user.firstname = firstname;
            user.lastname = lastname;
            user.email = email;
            user.password = password;

            // Save changes to the database
            fe.SaveChanges();

            // Redirect to a different action (e.g., ShowUser)
            return RedirectToAction("ShowUser");
        }
        public ActionResult Delete(int id)
        {
            projectEntities fe = new projectEntities();
            var user = fe.users.Find(id);
            fe.users.Remove(user);
            fe.SaveChanges();
            return RedirectToAction("ShowUser");
        }


        public ActionResult AddUserToDatabase(FormCollection fc)
        {
            String firstName = fc["firstname"];
            String lastName = fc["lastname"];
            String email = fc["email"];
            String diko = fc["password"];

            user use = new user();
            use.firstname = firstName;
            use.lastname = lastName;
            use.email = email;
            use.password = diko;
            use.role_id = 2;

            projectEntities fe = new projectEntities();
            fe.users.Add(use);
            fe.SaveChanges();

            //insert the code that will save these information to the DB

            return RedirectToAction("ShowUser");
        }
    }
}