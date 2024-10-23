using CSharpFunctionalExtensions;
using MediatR;

namespace Common.Core.Abstractions
{
    public interface IRequestBase { }
    public interface IQuery<TResponse> : IRequestBase, IRequest<Result<TResponse>>
        where TResponse : notnull
    { }
}
