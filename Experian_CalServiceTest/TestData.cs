using Experian_ChangeCalcService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experian_CalServiceTest
{
    public static class TestData
    {
        public static readonly Dictionary<string, decimal> Denominations = new Dictionary<string, decimal>
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

        public static readonly Dictionary<string, int> CalculateChangeResponse = new Dictionary<string, int>
    {
                { "£50", 1 },
                { "£20", 1 },
                { "£10", 1 }
    };

        public static readonly ChangeRequestModel ChangeRequestModel = new ChangeRequestModel
    {
              PaidAmount = 100.0m,
              PurchaseAmount = 20.0m
    };


        public static readonly ChangeRequestModel ChangeRequestModelForException = new ChangeRequestModel
        {
            PaidAmount = 100.0m,
            PurchaseAmount = 120.0m
        };
    }

}
