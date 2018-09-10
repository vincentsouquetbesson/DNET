using System;
using SocialNetwork.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    [RoutePrefix("login")]
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("login")]
        public ActionResult Login(String mail, String password)
        {
            System.Diagnostics.Debug.WriteLine("*******************************");
            System.Diagnostics.Debug.WriteLine("     LOGIN");
            System.Diagnostics.Debug.WriteLine("*******************************");
            SocialMediaBdd db = new SocialMediaBdd(); //ouverture de la bdd


            if (mail == null || password == null)
            {
                System.Diagnostics.Debug.WriteLine("mail ou pass null");
                return View();
            }

            IQueryable<UserTO> userQuery = db.User.Where(
            b => b.Mail.Equals(mail) & b.Password.Equals(password))
                    .Select(b => new UserTO
                    {
                        Id = b.Id,
                        Mail = b.Mail,
                        FirstName = b.FirstName,
                        LastName = b.LastName
                    });
            // UserTO userTest = user;
            foreach (UserTO user in userQuery)
            {
                if (user.Mail == mail)
                {   //si une valeur est retourné c'est que le mail est le pass sont juste
                    System.Diagnostics.Debug.WriteLine("Juste");


                    // a changer
                    Properties.Settings.Default["Id"] = user.Id;
                    Properties.Settings.Default["LastName"] = user.LastName;
                    Properties.Settings.Default["Mail"] = user.Mail;
                    Properties.Settings.Default["FirstName"] = user.FirstName;
                    Properties.Settings.Default.Save();

                    return RedirectToAction("../personalspace");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("mail faux");
                }
                continue;
            }
            return View();
        }
    }
}