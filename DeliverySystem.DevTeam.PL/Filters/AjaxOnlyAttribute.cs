

namespace DeliverySystem.DevTeam.PL.Filters
{
	public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
	{
		public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
		{
			var Request = routeContext.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";
			return Request;
		}
	}
}
