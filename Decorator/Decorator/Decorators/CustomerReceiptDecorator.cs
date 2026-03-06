using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Decorators
{
    internal abstract class CustomerReceiptDecorator (ICustomerReceipt underlying) : ICustomerReceipt
    {
        public int CalculateAmount()
        {
            return underlying.CalculateAmount();
        }

        public int Amount { get; set; }
    }
}
