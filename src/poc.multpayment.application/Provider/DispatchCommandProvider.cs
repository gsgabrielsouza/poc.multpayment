using MediatR;
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
        private readonly IMediator mediator;
        List<CommandsMap> commands = new List<CommandsMap>();

        public DispatchCommandProvider(
            IEnumerable<IMapProviderCommand> commands,
            IMediator mediator)
        {
            foreach (var item in commands)
                this.commands.AddRange(item.Commands);
            this.mediator = mediator;
        }

        public async Task<TResult> Execute<TCommand, TResult>(TCommand command)
            where TCommand : BaseCommand
            where TResult : class
        {
            var handler = typeof(ICommandHandler<,>);
            var commandType = commands.FirstOrDefault(x => x.CommandType == command.GetType() && x.ProviderType == command.Provider);

            if (commandType == null)
                throw new Exception($"Commando {command.GetType().Name} não mapeado para provider {command.Provider}");

            var handlerType = handler.MakeGenericType(commandType.ProviderCommandType, typeof(TResult));
            var assemblyProviders = Assembly.GetCallingAssembly().GetReferencedAssemblies().Where(x => x.Name.ToLower().Contains("provider")).Select(e => Assembly.Load(e)).SelectMany(x => x.GetTypes());

            var result =  await mediator.Send(Activator.CreateInstance(commandType.ProviderCommandType, new object[] { command }));
            return result as TResult;
        }
    }
}
