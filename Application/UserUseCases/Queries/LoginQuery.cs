using MediatR;

namespace Application.UserUseCases.Queries;

public record LoginQuery(string Email,string Passowrd):IRequest<string>;
