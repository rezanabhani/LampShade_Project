using System;

namespace _0_Framework.Application
{
    public class RandomNumberGenerator
    {
        private static readonly Random random = new Random();

        public int GenerateRandomNumber()
        {
            // Generate a random 5-digit number (between 10000 and 99999)
            return random.Next(10000, 100000);
        }
    }
}
