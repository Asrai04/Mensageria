using Mesageria;
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
        Text texto = new();
        HttpListener listener = new();
        listener.Prefixes.Add("http://localhost:60001/");
        listener.Start();

        while (true)
        {
            HttpListenerContext context = await listener.GetContextAsync();

            string? url = context.Request.RawUrl;
            int CReturn = (int)HttpStatusCode.OK;
            string mensaje = "";

            if (url == null)
            {
                mensaje = "URL vacia";
                CReturn = (int)HttpStatusCode.InternalServerError;
            }
            else if (url.StartsWith("/conectar"))
            {
                mensaje = "todo niceeeeee";
            }
            else if (url.StartsWith("/escribir"))
            {
                var MsgUsua = context.Request.QueryString.Get("txt");

                if (MsgUsua != null)
                {
                    texto.Escribe(MsgUsua);
                    mensaje = "OK";
                }

                else CReturn = (int)HttpStatusCode.InternalServerError;
            }
            else if (url.StartsWith("/mostrar"))
            {
                mensaje = texto.Mandar();
            }

            context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(mensaje);
            context.Response.StatusCode = CReturn;
            using (Stream s = context.Response.OutputStream)
            using (StreamWriter writer = new(s))
                await writer.WriteAsync(mensaje);

        }
    }
}