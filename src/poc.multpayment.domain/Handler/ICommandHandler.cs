using System.Threading.Tasks;

namespace poc.multpayment.domain.Handler
{
    public interface ICommandHandler<TCommand, TResult>
        where TCommand : class
        where TResult : class
    {
        Task<TResult> Handle(TCommand command);
    }
}
