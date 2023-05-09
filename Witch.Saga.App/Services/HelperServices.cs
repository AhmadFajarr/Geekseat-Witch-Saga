using System.Collections.Generic;
using System.Linq;

namespace Witch.Saga.App.Services
{
    public class HelperServices
    {
        public int CalculateAverageNumber(int killedYear)
        {
            int averageNumber = 0;
            List<int> listInt = new List<int>();
            if (killedYear < 0)
            {
                averageNumber = -1;
            }
            else if (killedYear == 1)
            {
                averageNumber = killedYear;
            }
            else
            {
                for (int i = 2; i < killedYear + 1; i++)
                {
                    int primeNumber = GetPrimeNumber(i);
                    if (primeNumber > 0)
                        listInt.Add(primeNumber);
                }

                int sumOfListInt = listInt.Sum(x => x);
                if (sumOfListInt <= 2)
                {
                    averageNumber = sumOfListInt;
                }
                else
                {
                    averageNumber = 2 + sumOfListInt;
                }
            }

            return averageNumber;
        }

        private int GetPrimeNumber(int number)
        {
            int n = 0;
            for (int i = 2; i < (number / 2 + 1); i++)
            {
                if (number % i == 0)
                {
                    n++;
                    break;
                }
            }

            if (n == 0)
            {
                return number;
            }
            else
            {
                return 0;
            }
        }
    }
}
