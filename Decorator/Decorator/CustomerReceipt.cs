namespace Decorator;

internal class CustomerReceipt : ICustomerReceipt
{
    public int CalculateAmount()
    {
        Amount += 0;
        return Amount;
    }

    public int Amount { get; set; }
}