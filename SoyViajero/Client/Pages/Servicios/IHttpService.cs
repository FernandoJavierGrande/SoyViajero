
namespace SoyViajero.Client.Pages.Servicios
{
    public interface IHttpService
    {
        Task<HttpRespuesta<T>> Get<T>(string url);
    }
}