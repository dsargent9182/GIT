using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;

namespace WebApiMemberValue
{
	public class RequireHttpsAttribute : AuthorizationFilterAttribute
	{
		public override void OnAuthorization(HttpActionContext actionContext)
		{
			if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
			{
				actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.HttpVersionNotSupported);
				actionContext.Response.Content = new StringContent("Use HTTPS instead of HTTP");
			}
			else
			{
				base.OnAuthorization(actionContext);
			}
		}
	}
}