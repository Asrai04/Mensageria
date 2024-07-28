using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text;

internal class program()
{
    public static void Main(string[] args)
    {
        ListenAsync();
        Console.ReadKey();
    }
    async static void ListenAsync()
    {
        HttpListener listener = new();
        listener.Prefixes.Add("http://localhost:60001/");
        listener.Start();

        while (true)
        {
            HttpListenerContext context = await listener.GetContextAsync();

            string? url = context.Request.RawUrl;
            int CReturn = (int)HttpStatusCode.OK;
            string mensaje = "niceer";

            if (url == null)
            {
                mensaje = "URL vacia";
                CReturn = (int)HttpStatusCode.InternalServerError;
            }
            else if (url.StartsWith("/conectar"))
            {
                mensaje = "todo niceeeeee";
            }

            context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(mensaje);
            context.Response.StatusCode = CReturn;
            using (Stream s = context.Response.OutputStream)
            using (StreamWriter writer = new(s))
                await writer.WriteAsync(mensaje);

        }
    }
}