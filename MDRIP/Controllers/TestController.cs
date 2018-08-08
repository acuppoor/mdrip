using MDRIP.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MDRIP.Controllers
{
    public class TestController : ApiController
    {
		private MDRIPContext db = new MDRIPContext();

		public IEnumerable<Infections> GetAllInfections()
		{
			return db.Infections.ToList();
		}
	}
}
