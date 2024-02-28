namespace Experian_ChangeCalcService.Services.Contract
{
    public interface IDenominationService
    {
        /// <summary>
        /// Get the all available denominations for the currency
        /// </summary>
        /// <returns> A Dictionary of Denominations</returns>
        Dictionary<string, decimal> GetDenominations();
    }
}
