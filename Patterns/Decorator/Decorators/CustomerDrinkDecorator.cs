using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Decorator.Decorators
{
    internal class CustomerDrinkDecorator(ICustomerReceipt underlying, ILogger<CustomerDrinkDecorator> logger) : CustomerReceiptDecorator(underlying), ICustomerReceipt
    {
        private const int _drinkAmount = 600;
        public int CalculateAmount()
        {
            logger.LogInformation("Calculating amount for drink {amount}", _drinkAmount);
            return underlying.CalculateAmount() + _drinkAmount;
        }
    }
}
