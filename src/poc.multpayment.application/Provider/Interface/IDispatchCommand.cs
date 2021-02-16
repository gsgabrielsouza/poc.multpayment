using poc.multpayment.domain.Command;
using System.Threading.Tasks;

namespace poc.multpayment.application.Provider.Interface
{
    public interface IDispatchCommand
    {
        Task<TResult> Execute<TCommand, TResult>(TCommand command)
            where TCommand : BaseCommand 
            where TResult : class;
    }
}
