namespace Elmah
{
    using System.Web;

    static class ErrorTruncationHandler
    {
        public static void ProcessRequest(HttpContextBase context)
        {
            var response = context.Response;
            response.ContentType = "application/xml";

            ErrorLog.GetDefault(context).Truncate();
            
            var redirectUrl = context.Request.ServerVariables["URL"];
            context.Response.Redirect(redirectUrl, true);
        }
    }
}