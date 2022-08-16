using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemoApp.Services
{

	public interface IHomeServices
	{
		string FullName(string firstName, string lastname);
	}

	public class HomeServices : IHomeServices
	{
		public string FullName(string firstName, string lastname)
		{
			return $"Full Name : {firstName} {lastname}";
			
		}
	}
}
