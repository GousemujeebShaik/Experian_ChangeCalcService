using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Experian_ChangeCalcService.Models
{
    public class ChangeRequestModel
    {
        /// <summary>
        /// The purchase amount
        /// </summary>
        [JsonPropertyName("PurchaseAmount")]
        [Description("The total PurchaseAmount.")]
        public decimal PurchaseAmount { get; set; }

        /// <summary>
        /// The total paid Amount.
        /// </summary>
        [JsonPropertyName("PaidAmount")]
        [Description("The total PaidAmount.")]
        public decimal PaidAmount { get; set; }

    }

}
