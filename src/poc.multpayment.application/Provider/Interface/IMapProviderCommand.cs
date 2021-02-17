using poc.multpayment.application.Provider.Map;
using System.Collections.Generic;

namespace poc.multpayment.application.Provider.Interface
{
    public interface IMapProviderCommand
    {
        List<CommandsMap> Commands { get;}
    }
}
