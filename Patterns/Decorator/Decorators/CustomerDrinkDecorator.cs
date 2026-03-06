using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Decorator.Decorators
{
    internal class CustomerDrinkDecorator(ICustomerReceipt underlying, ILogger<CustomerDrinkDecorator> logger) : CustomerReceiptDecorator(underlying), ICustomerReceipt
    {
        private readonly ICustomerReceipt _underlying = underlying;
        private const int DrinkAmount = 600;
        public new int CalculateAmount()
        {
            logger.LogInformation("Calculating amount for drink {amount}", DrinkAmount);
            return _underlying.CalculateAmount() + DrinkAmount;
        }
    }
}
