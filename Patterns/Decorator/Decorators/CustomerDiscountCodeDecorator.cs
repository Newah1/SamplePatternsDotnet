using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Decorators
{
    internal class CustomerDiscountCodeDecorator(ICustomerReceipt underlying) : CustomerReceiptDecorator(underlying), ICustomerReceipt
    {
        private readonly ICustomerReceipt _underlying = underlying;

        public new int CalculateAmount()
        {
            return (int)Math.Floor(_underlying.CalculateAmount() * 0.275);
        }
    }
}
