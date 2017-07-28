using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticeForFriday.Models;
using System.Diagnostics;

namespace PracticeForFriday.Filters
{
	public class CustomerFilter : ActionFilterAttribute,IActionFilter,IExceptionFilter,IResultFilter
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			Console.WriteLine("Before Action executed");
			base.OnActionExecuting(filterContext);
		}
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			Console.WriteLine("After Action executed");
			base.OnActionExecuted(filterContext);
		}
		public override void OnResultExecuted(ResultExecutedContext filterContext)
		{
			Console.WriteLine("After result executed");
			base.OnResultExecuted(filterContext);
		}
		public override void OnResultExecuting(ResultExecutingContext filterContext)
		{
			Console.WriteLine("Before Action executed");
			base.OnResultExecuting(filterContext);
		}

		public void OnException(ExceptionContext filterContext)
		{
			throw new NotImplementedException();
		}
	}
}