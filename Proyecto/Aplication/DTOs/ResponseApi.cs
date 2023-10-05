using System.Net;

namespace Proyecto.API.Aplication.DTOs
{
    public class ResponseApi<T>
    {
        public HttpStatusCode Status { get; set; }
        public string StatusText { get; set; }
        public T Data { get; set; }
    }
}
