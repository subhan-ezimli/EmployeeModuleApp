using CSharpFunctionalExtensions;
using MediatR;

namespace Common.Core.Abstractions
{
    public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>>
        where TRequest : IQuery<TResponse>
        where TResponse : notnull { }
}
