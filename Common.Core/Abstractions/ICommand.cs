using CSharpFunctionalExtensions;
using MediatR;

namespace Common.Core.Abstractions
{
    public interface ICommand<TResponse> :IRequestBase, IRequest<Result<TResponse>>
        where TResponse : notnull { }

    public interface ICommand : IRequestBase, IRequest<Result<Unit>> { }
}
