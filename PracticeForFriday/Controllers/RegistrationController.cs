using System.Web.Mvc;
using PracticeForFriday.Models;

namespace PracticeForFriday.Controllers
{
	[RoutePrefix("Create_An_User")]
	[Route("{action=registration}")]
	public class RegistrationController : Controller
    {
        // GET: Registration
		[AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }
		[HttpPost]
		[AllowAnonymous]
		public ActionResult Registration(ViewModel vm)
		{
			if (ModelState.IsValid)
			{
				using (mvcEntities me = new mvcEntities())
				{
					Employee emp = new Employee();
					emp.first_name = vm.Employee.first_name;
					emp.last_name = vm.Employee.last_name;
					emp.loginID = vm.Employee.loginID;
					emp.loginPassword = vm.Employee.loginPassword;
					emp.Email_Address = vm.Employee.Email_Address;
					emp.Home_Address = vm.Employee.Home_Address;
					emp.Phone = vm.Employee.Phone;
					me.Employees.Add(emp);
					me.SaveChanges();
					return RedirectToAction("Login","SignIn");
				}
			}
			else {
				return View(vm);
			}
		}
	}
}