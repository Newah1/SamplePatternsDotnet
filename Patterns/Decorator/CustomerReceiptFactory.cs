using System;
using System.Collections.Generic;
using System.Text;
using Decorator.Decorators;
using Microsoft.Extensions.DependencyInjection;

namespace Decorator
{
    internal class CustomerReceiptFactory
    {
        public static ICustomerReceipt? GetCustomerReceipt(CustomerReceiptSettings settings, IServiceProvider serviceProvider)
        {
            var decorators = GetTypes();

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

                adapter = TryCreateInstance(matchingType, args, serviceProvider);

                if (adapter == null)
                {
                    continue;
                }

                adapters.Add((CustomerReceiptDecorator)adapter);
                previousAdapter = (CustomerReceiptDecorator)adapter;
            }

            return previousAdapter;
        }

        private static object? TryCreateInstance(Type matchingType, object?[]? args, IServiceProvider serviceProvider)
        {
            try
            {
                var adapter = ActivatorUtilities.CreateInstance(serviceProvider, matchingType, args);
                return adapter;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Type> GetTypes()
        {
            var decorators = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(d => d.GetTypes())
                .Where(t => t.IsSubclassOf(typeof(CustomerReceiptDecorator)))
                .ToList();

            return decorators;
        }
    }

    internal record CustomerReceiptSettings(List<string> Adapters)
    {
        public List<string> Adapters { get; set; } = Adapters;
    }
}
