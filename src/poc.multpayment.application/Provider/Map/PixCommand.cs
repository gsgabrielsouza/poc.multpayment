using poc.multpayment.application.Services.v1.Command.PaymentCommand;
using poc.multpayment.domain.Command;
using poc.multpayment.pix.Command;
using System.Collections.Generic;

namespace poc.multpayment.application.Provider.Map
{
    internal class PixCommand
    {
        internal List<CommandsMap> commands = new List<CommandsMap>();

        public PixCommand()
        {
            commands.Add(new CommandsMap(
                typeof(PaymentAuthorizeCommand),
                typeof(PixPaymentAuthorizeCommand),
                ProviderEnum.Cielo));
        }
    }
}
