using System;

namespace LoanCalculator.Helpers
{
    public class Reader
    {
        public static T ReadInput<T>(string message)
        {
            Console.WriteLine($"{message}: ");
            return ReadInput<T>();
        }

        private static T ReadInput<T>()
        {
            var input = Console.ReadLine();
            return (T) Convert.ChangeType(input, typeof(T));
        }
    }
}