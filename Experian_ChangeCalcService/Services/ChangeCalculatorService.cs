using Experian_ChangeCalcService.Services.Contract;

namespace Experian_ChangeCalcService.Services
{
    public class ChangeCalculatorService : IChangeCalculatorService
    {
        private readonly IDenominationService _denominationService;

        public ChangeCalculatorService(IDenominationService denominationService)
        {
            _denominationService = denominationService;
        }

        /// <InheritDoc/>
        public Dictionary<string, int> CalculateChange(decimal purchaseAmount, decimal paidAmount)
        {
            var change = paidAmount - purchaseAmount;
            if (change < 0)
            {
                throw new InvalidOperationException("Insufficient amount paid");
            }

            var denominations = _denominationService.GetDenominations();

            var changeDict = new Dictionary<string, int>();

            foreach (var kvp in denominations.OrderByDescending(d => d.Value))
            {
                int count = (int)(change / kvp.Value);
                if (count > 0)
                {
                    changeDict.Add(kvp.Key, count);
                    change -= count * kvp.Value;
                }
            }

            return changeDict;
        }

    }
}
