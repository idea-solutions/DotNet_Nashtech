namespace DAY04.Middlewares
{
    public class LogginMiddleware
    {
        private readonly RequestDelegate _next;

        public LogginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            var request = context.Request;

            string requestInfo = $"Scheme: {request.Scheme}\n\r"
            + $"Host: {request.Host}\n\r"
            + $"Path: {request.Path}\n\r"
            + $"QueryString: {request.QueryString}\n\r"
            + $"Body: {request.Body}\n\r";

            using FileStream fileStream = File.Create("requestInfo.txt");
            using var streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(requestInfo);

            await _next(context);
        }
    }
}