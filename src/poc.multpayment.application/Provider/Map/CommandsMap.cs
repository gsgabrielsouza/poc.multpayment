using poc.multpayment.domain.Command;
using System;

namespace poc.multpayment.application.Provider.Map
{
    public class CommandsMap
    {
        public CommandsMap(Type commandType, Type providerCommandType, ProviderEnum providerType)
        {
            CommandType = commandType;
            ProviderCommandType = providerCommandType;
            ProviderType = providerType;
        }

        public Type CommandType { get;  }
        public Type ProviderCommandType { get;  }
        public ProviderEnum ProviderType { get; }
    }
}
