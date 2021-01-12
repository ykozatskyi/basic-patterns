using Common;
using System;

namespace FactoryMethodExample
{
    abstract class PaymentConnector
    {
        public abstract decimal GetBalance();
    }

    class PayPal : PaymentConnector
    {
        public override decimal GetBalance() => 99.99m;
    }

    class Stripe : PaymentConnector
    {
        public override decimal GetBalance() => 88.88m;
    }

    abstract class PaymentService
    {
        public abstract PaymentConnector GetClient();
    }

    class PayPalService : PaymentService
    {
        public override PaymentConnector GetClient() => new PayPal();
    }

    class StripeService : PaymentService
    {
        public override PaymentConnector GetClient() => new Stripe();
    }

    class Program
    {
        /// <summary>
        /// working with interface, client didn't know anything about service type. It's only interface 
        /// </summary>
        private static PaymentService _paymentClient;

        static void Main(string[] args)
        {
            if (args.IsNullOrEmpty())
                return;

            Initialize(args[0]);
            var client = _paymentClient.GetClient();
            var balance = client.GetBalance();

            Console.WriteLine($"Your balance is ${balance}");
        }

        private static void Initialize(string clientType)
        {
            switch (clientType)
            {
                case "paypal":
                    _paymentClient = new PayPalService();
                    break;
                case "stripe":
                    _paymentClient = new StripeService();
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
