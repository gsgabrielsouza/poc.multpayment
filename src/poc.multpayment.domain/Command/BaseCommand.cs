namespace poc.multpayment.domain.Command
{
    public class BaseCommand
    {
        public BaseCommand(ProviderEnum providerEnum)
        {
            Provider = providerEnum;
        }

        public ProviderEnum Provider { get; private set; }
    }
}
