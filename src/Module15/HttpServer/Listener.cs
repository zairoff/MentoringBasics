using System;
using System.Net;
using System.Web;

namespace HttpServer
{
    public class Listener
    {
        private readonly HttpListener _httpListener;

        public Listener(string url)
        {
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add(url);
        }

        public void Start()
        {
            if (_httpListener.IsListening)
                return;

            _httpListener.Start();
        }

        public void Stop()
        {
            if (_httpListener.IsListening)
            {
                _httpListener.Stop();
            }
        }

        public bool Listen()
        {
            if (!_httpListener.IsListening)
                throw new InvalidOperationException();

            var context = _httpListener.GetContext();
            var request = context.Request;
            
            var path = request?.Url?.AbsolutePath.Replace("/", "");

            HttpStatusCode statusCode = HttpStatusCode.OK;
            HttpListenerResponse response = context.Response;

            var run = true;
            string responseValue = path;
            switch (path?.ToLower())
            {
                case "mynamebyheader":

                    responseValue = request.Headers["X-MyName"];
                    statusCode = HttpStatusCode.OK;
                    break;

                case "mynamebycookies":

                    responseValue = HttpUtility.ParseQueryString(request?.Url?.Query).Get("name");
                    Cookie cookie = new()
                    {
                        Name = "MyName",
                        Value = responseValue
                    };
                    response.Cookies.Add(cookie);

                    statusCode = HttpStatusCode.OK;
                    break;
                case "myname":

                    responseValue = HttpUtility.ParseQueryString(request?.Url?.Query).Get("name");
                    statusCode = HttpStatusCode.OK;
                    break;

                case "information":

                    statusCode = HttpStatusCode.Continue;
                    break;

                case "success":

                    statusCode = HttpStatusCode.OK;
                    break;

                case "redirection":

                    statusCode = HttpStatusCode.Redirect;
                    break;

                case "clienterror":

                    statusCode = HttpStatusCode.BadRequest;
                    break;

                case "servererror":

                    statusCode = HttpStatusCode.InternalServerError;
                    break;

                case "exit":

                    statusCode = HttpStatusCode.OK;
                    run = false;
                    break;

                default: break;
            }

            
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseValue);
            response.ContentLength64 = buffer.Length;
            response.StatusCode = (int)statusCode;

            using var output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();

            return run;
        }
    }
}
