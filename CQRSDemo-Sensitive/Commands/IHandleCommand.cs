using System.Threading.Tasks;

namespace CQRSDemo.Commands
{
    using MediatR;

    public interface IHandleCommand<in TCommand> : IRequestHandler<TCommand, CommandResult>
        where TCommand : BaseCommand
    {
    }
}