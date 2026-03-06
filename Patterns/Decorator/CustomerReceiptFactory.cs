using System;
using System.Collections.Generic;
using System.Text;
using Decorator.Decorators;

namespace Decorator
{
    internal class CustomerReceiptFactory
    {
        public ICustomerReceipt? GetCustomerReceipt(CustomerReceiptSettings settings)
        {
            var decorators = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(d => d.GetTypes())
                .Where(t => t.IsSubclassOf(typeof(CustomerReceiptDecorator)))
                .ToList();

            var adapters = new List<CustomerReceiptDecorator>();

            CustomerReceiptDecorator? previousAdapter = null;
            var underlyingCustomerReceipt = new CustomerReceipt();

            foreach (var adapterS in settings.Adapters)
            {
                var matchingType = decorators.FirstOrDefault(d => d.Name.Replace("Decorator", string.Empty) == adapterS);
                if (matchingType == null)
                {
                    continue;
                }

                object? adapter;
                object[] args = [previousAdapter];
                if (previousAdapter == null)
                {
                    args = [underlyingCustomerReceipt];
                }

                adapter = TryCreateInstance(matchingType, args);

                if (adapter == null)
                {
                    continue;
                }

                adapters.Add((CustomerReceiptDecorator)adapter);
                previousAdapter = (CustomerReceiptDecorator)adapter;
            }

            return previousAdapter;
        }

        private object? TryCreateInstance(Type matchingType, object?[]? args)
        {
            try
            {
                var adapter = Activator.CreateInstance(matchingType, args);
                return adapter;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }

    internal record CustomerReceiptSettings(List<string> Adapters)
    {
        public List<string> Adapters { get; set; } = Adapters;
    }
}
