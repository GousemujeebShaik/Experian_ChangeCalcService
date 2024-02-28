using Experian_ChangeCalcService.Services.Contract;

namespace Experian_ChangeCalcService.Services
{
    public class DenominationService : IDenominationService
    {
        /// <InheritDoc/>
        public Dictionary<string, decimal> GetDenominations()
        {
            return new Dictionary<string, decimal>
        {
            { "£50", 50 },
            { "£20", 20 },
            { "£10", 10 },
            { "£5", 5 },
            { "£2", 2 },
            { "£1", 1 },
            { "50p", 0.5m },
            { "20p", 0.2m },
            { "10p", 0.1m },
            { "5p", 0.05m },
            { "2p", 0.02m },
            { "1p", 0.01m }
        };
        }
    }
}
