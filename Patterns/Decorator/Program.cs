using Decorator;

// could be dynamic, apply two decorators in settings
var config = new CustomerReceiptSettings(new List<string>() { "CustomerDrink", "CustomerDiscountCode" });

var customerReceipt= new CustomerReceiptFactory().GetCustomerReceipt(config);

var amount = customerReceipt?.CalculateAmount() ?? -1;

Console.WriteLine(amount);