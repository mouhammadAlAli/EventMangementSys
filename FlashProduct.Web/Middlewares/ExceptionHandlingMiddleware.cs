using Domain.Exceptions;

namespace FlashProduct.Web.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate next;
    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync(ex.Message);
        }
        catch (DomainException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync(ex.Message);
        }
    }
}
