using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PracticeForFriday.Models;

namespace PracticeForFriday.Controllers
{
	[RoutePrefix("Project")]
	[Route("{action=Login}")]
	[AllowAnonymous]
    public class SignInController : Controller
    {
        // GET: SignIn
        public ActionResult Login()
        {
				return View();
        }
		[HttpPost]
		[AllowAnonymous]
		public ActionResult Login(ViewModel vm) {
			using (mvcEntities ME = new mvcEntities())
			{
				Employee emp = new Employee();
				emp.loginID = vm.Employee.loginID;
				emp.loginPassword = vm.Employee.loginPassword;
				
				bool result = ME.Employees.Where(x => x.loginID == emp.loginID && x.loginPassword == emp.loginPassword).Any();
				if (result)
				{
					FormsAuthentication.SetAuthCookie(emp.loginID, false);
					Session["user"] = emp;
					var employee = ME.Employees.Where(x => x.loginID == emp.loginID && x.loginPassword == emp.loginPassword).First();
					Session["imgUrl"] = employee.Portrait;
					Session["ID"] = employee.userid;
					return RedirectToAction("DataBody", "Content");
				}
				else
				{
					return View(vm);
				}
			}
		}
		[Route("Student")]
		public string getstring(string a)
		{
			return "a";
		}
    }
}