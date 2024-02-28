namespace Experian_ChangeCalcService.Services.Contract
{
    public interface IChangeCalculatorService
    {
        /// <summary>
        /// Calculates the change denominations based on the purchase amount and paid amount.
        /// </summary>
        /// <param name="purchaseAmount">The total amount puchased.</param>
        /// <param name="paidAmount">The amount paid.</param>
        /// <returns>A dictionary of denomination values and their counts representing the change.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the amount paid is less than the amount purchased.</exception>

        Dictionary<string, int> CalculateChange(decimal purchaseAmount, decimal paidAmount);
    }
}
