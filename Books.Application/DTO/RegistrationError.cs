namespace Books.Application.DTO
{
    public class RegistrationError
    {
        public string Error { get; set; }
        public string Parameter { get; set; }

        public RegistrationError(string error, string parametr)
        {
            Error = error;
            Parameter = parametr;
        }
    }
}
