namespace YellowPages.Shared.Dtos
{
    public class Response<T>
    {
        public T Data { get; set; }

        [System.Text.Json.Serialization.JsonIgnoreAttribute]
        public int StatusCode { get; set; }

        [System.Text.Json.Serialization.JsonIgnoreAttribute]
        public bool IsSuccessful { get; set; }

        public System.Collections.Generic.List<string> Errors { get; set; }


        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default, StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T> Fail(System.Collections.Generic.List<string> errors, int statusCode)

        {
            return new Response<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T>
            {
                Errors = new System.Collections.Generic.List<string> { error }, StatusCode = statusCode,
                IsSuccessful = false
            };
        }
    }
}