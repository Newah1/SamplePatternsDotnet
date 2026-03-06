using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    internal interface ICustomerReceipt
    {
        public int CalculateAmount();
        public int Amount { get; set; }
    }
}
