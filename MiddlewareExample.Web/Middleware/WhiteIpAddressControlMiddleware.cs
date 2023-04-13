using System.Net;

namespace MiddlewareExample.Web.Middleware
{
    public class WhiteIpAddressControlMiddleware
    {
        //Middleware olarak kullanılabilmesi için 2  tane kuralımız var .
        //Birincisi RequestDelegate 'i constructor olarak geçmesi lazım..
        //InvokAsync Methodunu içermesi gerekmektedir.

        private readonly RequestDelegate _requestDelegate;
        private const string WhiteIpAddress = "192.10.154.88";

        public WhiteIpAddressControlMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //IPV4 => 127.0.0.1  localhost
            //IPV6 => ::1 localhost
            var reqIpAddress = context.Connection.RemoteIpAddress;

            bool anyWhiteIpAddress = IPAddress.Parse(WhiteIpAddress).Equals(reqIpAddress); 
            // IPAddress Parse ile Yukarıda string olarak verdiğimiz ::1 'i IPAddress formatına cevirdik.
            // Sonra Equals ile karşılaştır diyerek reqIpAddress ile karşılaştırdık. eşleşiyorsa true dönecek.

            if (anyWhiteIpAddress==true) 
            {
                await _requestDelegate(context);
            }
            else
            {
                context.Response.StatusCode= HttpStatusCode.Forbidden.GetHashCode();
                await context.Response.WriteAsync("!!Forbidden!!");
            }
        }
    }
}
