using System;

namespace FactoryMethodExample
{
    class Program
    {
        /// <summary>
        /// working with interface, client didn't know anything about which type of service was created. 
        /// </summary>
        private static PaymentService _paymentClient;

        static void Main(string[] args)
        {
            if (args.IsNullOrEmpty())
                return;

            Initialize(args[0]);
            var client = _paymentClient.GetClient();

            Console.WriteLine($"Your balance is ${client.GetBalance()}");
        }

        static bool Initialize(string clientType)
        {
            switch (clientType)
            {
                case "paypal":
                    _paymentClient = new PayPalService();
                    return true;
                case "stripe":
                    _paymentClient = new StripeService();
                    return true;
                default:
                    return false;
            }
        }
    }

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

    static class ArrayExtensions
    {
        public static bool IsNullOrEmpty(this Array array)
        {
            return (array == null || array.Length == 0);
        }
    }
}
