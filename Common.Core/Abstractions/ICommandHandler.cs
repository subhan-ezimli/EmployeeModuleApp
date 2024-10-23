﻿using CSharpFunctionalExtensions;
using MediatR;

namespace Common.Core.Abstractions
{
    public interface ICommandHandler<TRequest,TResponse>:IRequestHandler<TRequest,Result<TResponse>>
        where TRequest:ICommand<TResponse>
        where TResponse : notnull { }

    public interface ICommandHandler<TRequest> : IRequestHandler<TRequest, Result<Unit>>
        where TRequest : ICommand { }
}
