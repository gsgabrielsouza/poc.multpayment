using poc.multpayment.application.Provider.Interface;
using poc.multpayment.domain.Command;
using poc.multpayment.domain.Handler;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace poc.multpayment.application.Provider
{
    public class DispatchCommandProvider : IDispatchCommand
    {
        public Task<TResult> Execute<TCommand, TResult>(TCommand command)
            where TCommand : BaseCommand
            where TResult : class
        {
            var handler = typeof(ICommandHandler<,>);
            var handlerType = handler.MakeGenericType(command.GetType(), typeof(TResult));

            var concretesType = Assembly.GetExecutingAssembly().GetTypes().First(x => x.IsClass && x.GetInterfaces().Contains(handlerType));

            if (concretesType == null) throw new Exception($"not found command implementation");

            var concreteHandler = Activator.CreateInstance(concretesType) as ICommandHandler<TCommand, TResult>;
            return concreteHandler?.Handle(command);
        }
    }
}
