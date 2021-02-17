using poc.multpayment.application.Provider.Interface;
using poc.multpayment.application.Provider.Map;
using poc.multpayment.domain.Command;
using poc.multpayment.domain.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace poc.multpayment.application.Provider
{
    public class DispatchCommandProvider : IDispatchCommand
    {
        List<CommandsMap> commands = new List<CommandsMap>();

        public DispatchCommandProvider(IEnumerable<IMapProviderCommand> commands)
        {
            foreach (var item in commands)
                this.commands.AddRange(item.Commands);
        }

        public Task<TResult> Execute<TCommand, TResult>(TCommand command)
            where TCommand : BaseCommand
            where TResult : class
        {
            var handler = typeof(ICommandHandler<,>);
            var handlerType = handler.MakeGenericType(command.GetType(), typeof(TResult));

            //var concretesType = Assembly.GetExecutingAssembly().GetTypes()
            //    .First(x => x.IsClass && 
            //                x.GetInterfaces().Contains(handlerType));
            var providerHandler = commands.FirstOrDefault(x => x.CommandType == command.GetType() && x.ProviderType == command.Provider);


            if (providerHandler == null) throw new Exception($"not found command implementation");

            var concreteHandler = Activator.CreateInstance(providerHandler.ProviderCommandType) as ICommandHandler<TCommand, TResult>;
            return concreteHandler?.Handle(command);
        }
    }
}
