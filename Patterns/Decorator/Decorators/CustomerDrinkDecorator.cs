using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Decorators
{
    internal class CustomerDrinkDecorator(ICustomerReceipt underlying) : CustomerReceiptDecorator(underlying), ICustomerReceipt
    {
        private const int _drinkAmount = 600;
        public int CalculateAmount()
        {
            return underlying.CalculateAmount() + _drinkAmount;
        }
    }
}
