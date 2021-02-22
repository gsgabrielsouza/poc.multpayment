using poc.multpayment.application.Provider.Interface;
using poc.multpayment.domain.Command;
using poc.multpayment.domain.Command.PaymentCommand;
using poc.multpayment.provider.cielo.Command;
using System.Collections.Generic;

namespace poc.multpayment.application.Provider.Map
{
    public class CieloCommand : IMapProviderCommand
    {
        List<CommandsMap> commands = new List<CommandsMap>();

        public List<CommandsMap> Commands => commands;

        public CieloCommand()
        {
            commands.Add(new CommandsMap(
                typeof(PaymentAuthorizeCommand),
                typeof(CieloPaymentAuthorizeCommand),
                ProviderEnum.Cielo));
        }

    }
}
