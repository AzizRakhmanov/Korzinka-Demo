namespace Korzinka_Demo.Services.Exeptions
{
    public class KorzinkaException : Exception
    {
        public KorzinkaException(int code = 400, string message = "Eror occured while processing the request")
            : base()
        {

        }
    }
}
