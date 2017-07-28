using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;

namespace PracticeForFriday.Models
{
	public class ViewModel
	{
		
		public EmployeeViewModel Employee { get; set; }
		public SubscriptionViewModel Subscription { get; set; }
		public IPagedList<SubscriptionViewModel> Subscriptions { get; set; }
		public Magazine Magazine { get; set; }
		public List<SubscriptionViewModel> subscriptionList { get; set; }
	}
	public class EmployeeViewModel
	{
		public int userid { get; set; }
		[Required(ErrorMessage = "Need First name")]
		public string first_name { get; set; }
		[Required(ErrorMessage = "Need Last name")]
		public string last_name { get; set; }
		[Required(ErrorMessage = "Need LoginID")]
		public string loginID { get; set; }
		[Required(ErrorMessage = "Need Password")]
		public string loginPassword { get; set; }
		[Required(ErrorMessage = "Need Email")]
		[EmailAddress(ErrorMessage = "Need a right email")]
		public string Email_Address { get; set; }
		[Required(ErrorMessage = "Need Home address")]
		public string Home_Address { get; set; }
		public Nullable<int> Phone { get; set; }
		public string Portrait { get; set; }
	}
	public class SubscriptionViewModel
	{
		public int SubscriptionID { get; set; }
		public Nullable<int> Magazine_ID { get; set; }
		public Nullable<System.DateTime> Start_Date { get; set; }
		public Nullable<System.DateTime> End_Date { get; set; }
		public string Active { get; set; }
		public Nullable<decimal> Rate { get; set; }
		public string User_ID { get; set; }
	}
}