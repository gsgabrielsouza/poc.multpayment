using poc.multpayment.application.Services.v1.Command.PaymentCommand;
using poc.multpayment.cielo.Command;
using poc.multpayment.domain.Command;
using System;
using System.Collections.Generic;

namespace poc.multpayment.application.Provider.Map
{
    internal class CieloCommand
    {
        internal List<CommandsMap> commands = new List<CommandsMap>();

        public CieloCommand()
        {
            commands.Add(new CommandsMap(   
                typeof(PaymentAuthorizeCommand), 
                typeof(CieloPaymentAuthorizeCommand), 
                ProviderEnum.Cielo));
        }
    }
}
