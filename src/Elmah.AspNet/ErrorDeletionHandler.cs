namespace Elmah
{
    using System.Net;
    using System.Web;
    using System.Xml;

    static class ErrorDeletionHandler
    {
        public static void ProcessRequest(HttpContextBase context)
        {
            var response = context.Response;
            response.ContentType = "application/xml";

            var errorId = context.Request.QueryString["id"] ?? string.Empty;
            if (errorId.Length == 0)
                throw new ApplicationException("Missing error identifier specification.");

            ErrorLog.GetDefault(context).Delete(errorId);
            
            var redirectUrl = context.Request.ServerVariables["URL"];
            context.Response.Redirect(redirectUrl, true);
        }
    }
}