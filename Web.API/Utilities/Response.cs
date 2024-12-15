namespace Web.API.Utilities
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public Response() { }

        public Response(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        // Método para respuestas de fallo con solo mensaje
        public static Response<T> FailureResponse(string message)
        {
            return new Response<T>(false, message, default(T));
        }

        // Método para respuestas de fallo con mensaje y datos
        public static Response<T> FailureResponse(string message, T data)
        {
            return new Response<T>(false, message, data);
        }

        // Método para respuestas exitosas
        public static Response<T> SuccessResponse(T data, string message)
        {
            return new Response<T>(true, message, data);
        }
    }
}