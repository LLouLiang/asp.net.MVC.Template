using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Web.Security;
using PracticeForFriday.Models;
using PracticeForFriday.Filters;

namespace PracticeForFriday.Controllers
{
	[RoutePrefix("Secret")]
	[Authorize]
	[HandleError]
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

		//[OutputCache(CacheProfile = "magazinelist")]
		[Route("content")]
		[CustomerFilter]
		[HandleError]
		public ActionResult DataBody()
		{
			using (mvcEntities me = new mvcEntities())
			{
				ViewModel vm = new ViewModel();
				//Employee employee = (Employee)TempData["user"];
				Employee employee = (Employee)Session["user"];
				string id = Convert.ToString(Session["ID"]);
				if (employee == null)
				{
					return RedirectToAction("Login", "SignIn");
				}
				List<Subscription> subscription = me.Subscriptions.Where(x => x.User_ID == id).ToList();
				List<SubscriptionViewModel> subscriptions = new List<SubscriptionViewModel>();
				foreach (var item in subscription)
				{
					SubscriptionViewModel subViewmodel = AutoMapper.Mapper.Map<Subscription, SubscriptionViewModel>(item);
					subscriptions.Add(subViewmodel);
				}
				//IPagedList<SubscriptionViewModel> subscriptionsViewModel = subscriptions.ToPagedList(page??1,5);
				//paged list
				//vm.Subscriptions = subscriptionsViewModel;
				// list 
				vm.subscriptionList = subscriptions;
				// Magazine list stored
				var magazines = me.Magazines.Select(x => x).ToList();
				Session["magazines"] = magazines;
				return View(vm);
			}
		}

		[Route("logout")]
		public ActionResult Signout() {
			FormsAuthentication.SignOut();
			Session.Abandon();
			return RedirectToAction("Login","SignIn");
		}
		[HttpPost]
		[AllowAnonymous]
		[HandleError]
		public void addPortrait(string portrait_url) {
			using (mvcEntities me = new mvcEntities())
			{
				if (ModelState.IsValid)
				{
					Employee emp = (Employee)Session["user"];
					Employee employee = me.Employees.Where(x => x.loginID == emp.loginID).FirstOrDefault();
					employee.Portrait = portrait_url;
					me.SaveChanges();
					HttpCookie cookie = new HttpCookie("portrait");
					
				}
			}
		}

		[HttpPost]
		[HandleError]
		public ActionResult Create(ViewModel s) {
			using (mvcEntities me = new mvcEntities()) {

				// setting pagedlist
				var subscription = me.Subscriptions.Where(x => x.User_ID == s.Subscription.User_ID).ToList();
				List<SubscriptionViewModel> subscriptionsViewModel = new List<SubscriptionViewModel>();
				foreach (var item in subscription)
				{
					SubscriptionViewModel subViewmodel = AutoMapper.Mapper.Map<Subscription, SubscriptionViewModel>(item);
					subscriptionsViewModel.Add(subViewmodel);
				}
				s.subscriptionList = subscriptionsViewModel;

				if (ModelState.IsValid) {
					bool mysub = me.Subscriptions.Where(x => x.SubscriptionID == s.Subscription.SubscriptionID && x.Magazine_ID == s.Subscription.Magazine_ID).Any();
					if (mysub) {
					}
					else
					{
						// Get  the largest subscription ID
						try
						{
							var lastone = me.Subscriptions.OrderByDescending(x => x.SubscriptionID).First();
							s.Subscription.SubscriptionID = lastone.SubscriptionID + 1;
							Subscription newSubscription = new Subscription();
							newSubscription = AutoMapper.Mapper.Map<SubscriptionViewModel, Subscription>(s.Subscription);
							me.Subscriptions.Add(newSubscription);
							me.SaveChanges();
						}
						catch
						{
							s.Subscription.SubscriptionID = 1;
							Subscription newSubscription = new Subscription();
							newSubscription = AutoMapper.Mapper.Map<SubscriptionViewModel, Subscription>(s.Subscription);
							me.Subscriptions.Add(newSubscription);
							me.SaveChanges();
						}
						
					}
					return RedirectToAction("DataBody", "Content",s);
				}
				else
				{
					return RedirectToAction("DataBody","Content",s);
				}
			}
		}
    }
}