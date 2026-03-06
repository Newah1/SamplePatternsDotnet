using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Decorators
{
    internal class CustomerDiscountCodeDecorator(ICustomerReceipt underlying) : CustomerReceiptDecorator(underlying), ICustomerReceipt
    {
        public int CalculateAmount()
        {
            return (int)Math.Floor(underlying.CalculateAmount() * 0.275);
        }
    }
}
