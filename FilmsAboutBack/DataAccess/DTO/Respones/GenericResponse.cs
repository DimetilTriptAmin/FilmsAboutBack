using System.Net;

namespace FilmsAboutBack.DataAccess.DTO.Respones
{
    public class GenericResponse<TValue>
    {
        public TValue Value { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSucceeded => string.IsNullOrEmpty(ErrorMessage);

        public GenericResponse(TValue response)
        {
            Value = response;
        }

        public GenericResponse(string message)
        {
            ErrorMessage = message;
        }
    }
}
