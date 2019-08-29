using System;
using System.Collections.Generic;
using System.Text;

namespace Hackajob
{
    public class SubPrimes
    {
        static public bool Run(int number)
        {
            /*if (IsPrime(number))
            {
                return true; // As it can be multiplied by 1
            }*/
            //find Primes up to number
            List<int> primes = new List<int>();
            for(int i = 0; i< number; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }

            int[] primeArray = primes.ToArray();
            for(int i = 0; i< primeArray.Length; i++)
            {
                for(int j=i; j< primeArray.Length; j++)
                {
                    if (primeArray[j] * primeArray[i] == number)
                        return true;
                }
            }

            bool isSemiprime = false;
            return isSemiprime;
        }
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
