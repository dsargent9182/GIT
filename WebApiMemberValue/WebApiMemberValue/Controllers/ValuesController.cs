using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiMemberValue.Models;

namespace WebApiMemberValue.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
		// GET api/values
		//public IEnumerable<MemberProductsValue> Get()
		//{
		//	return MemberProductsValue.GetList(null);
		//}

		// GET api/values/5
		public IEnumerable<MemberProductsValue> Get(string id)
		{
			return MemberProductsValue.GetList(String.Format("{0}", id));
		}

		//// POST api/values
		//public void Post([FromBody]string value)
  //      {
  //      }

  //      // PUT api/values/5
  //      public void Put(int id, [FromBody]string value)
  //      {
  //      }

  //      // DELETE api/values/5
  //      public void Delete(int id)
  //      {
  //      }
    }
}
