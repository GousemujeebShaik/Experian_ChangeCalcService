using Experian_ChangeCalcService.Models;
using Experian_ChangeCalcService.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Experian_ChangeCalcService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeCalculationController : ControllerBase
    {
        private readonly IChangeCalculatorService _changeCalculator;

        public ChangeCalculationController(IChangeCalculatorService changeCalculator)
        {
            _changeCalculator = changeCalculator;
        }

        /// <summary>
        /// Calculates the optimal change denominations to be returned.
        /// </summary>
        /// <param name="inputModel">The input model containing AmountDue and AmountPaid.</param>
        /// <returns>A dictionary of denomination values and their counts representing the change.</returns>
        /// <response code="200">Returns the change denominations.</response>
        /// <response code="400">If the amount paid is less than the amount due.</response>
        [HttpPost("CalculateChange")]
        [ProducesResponseType(typeof(Dictionary<string, int>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [SwaggerOperation(Summary = "Calculate change denominations",
                          Description = "Calculates the optimal change denominations to be returned.",
                          OperationId = "CalculateChange")]
        public IActionResult CalculateChange(ChangeRequestModel changeRequestModel)
        {
            try
            {
                if(changeRequestModel == null)
                {
                    return BadRequest("Incorrect input data");
                }
                else if(changeRequestModel.PaidAmount < changeRequestModel.PurchaseAmount)
                {
                    return BadRequest("Insufficient Amount");
                }
                var change = _changeCalculator.CalculateChange(changeRequestModel.PurchaseAmount, changeRequestModel.PaidAmount);
                return Ok(change);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
