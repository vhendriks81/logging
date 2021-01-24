namespace CQRSDemo.Commands
{
    using System;
    using MediatR;

    public abstract class BaseCommand
        : IRequest<CommandResult>
    {
        public Guid CommandId { get; } = Guid.NewGuid();
    }
}
