namespace Application.Exceptions;

public class ConflictException:ApplicationException
{
    public ConflictException()
    {
            
    }
    public ConflictException(string message):base(message) 
    {
            
    }
}
