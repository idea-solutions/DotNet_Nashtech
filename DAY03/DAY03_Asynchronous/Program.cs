
namespace Asynchronous
{
    class Program
    {
        public static void Main(string[] args)
        {
            PrimeNumber(0, 100);
            PrimeNumber(101, 200);
            Console.ReadKey();
        }

        public static async void PrimeNumber(int firstNumber, int lastNumber)
        {
            await Task.Run(() =>
            {
                int count = 0;
                for (int i = firstNumber; i < lastNumber; i++)
                {
                    count = 0;
                    if (i > 1)
                    {
                        for (int j = 2; j < i; j++)
                        {
                            if (i % j == 0)
                            {
                                count = 1;
                                break;
                            }
                        }
                        if (count == 0)
                        {
                            Console.Write(i + " ");
                            Task.Delay(200).Wait();
                        }
                    }
                }
            });
        }
    }
}