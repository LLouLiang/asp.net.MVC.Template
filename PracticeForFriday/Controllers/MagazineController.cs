using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace PracticeForFriday.Controllers
{
	[AllowAnonymous]
    public class MagazineController : Controller
    {
        // GET: Magazine
        
		public ActionResult MagazineView(int? page)
		{
			using (mvcEntities me = new mvcEntities())
			{
				var magaines = me.Magazines.Select(x => x).ToList().ToPagedList(page ?? 1, 5);
				return View(magaines);
			}
				
		}
    }
}