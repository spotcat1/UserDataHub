
namespace Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base()
        {
        }

        public NotFoundException(string Message) : base(Message)
        {
        }

        public NotFoundException(string message, Exception InnerException) : base(message, InnerException)
        {
        }


        public NotFoundException(string name, object key) : base($"Entity {name} ({key}) was not found</p>")
        {
        }

    }
}
