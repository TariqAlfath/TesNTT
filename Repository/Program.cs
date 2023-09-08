// See https://aka.ms/new-console-template for more information
using System.Text.Json;

namespace NTTLogicTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Input Your Array Number First (Press N to Stop) : ");
                var input = new List<int>();
                bool stop = false;
                while (!stop)
                {
                    var keyPress = Console.ReadLine();
                    if (keyPress.ToLower() == "n")
                    {
                        stop = true;
                        break;
                    }
                    else
                    {
                        input.Add(int.Parse(keyPress));
                    }

                }
                Console.WriteLine("Your Summerize Value : ");
                var expectedResult = int.Parse(Console.ReadLine());

                Program program = new Program();

                Console.WriteLine(JsonSerializer.Serialize(program.showTwoNumberEqualsResult(input, expectedResult)));
                Console.WriteLine("Press enter to try again !");
                Console.ReadLine();
                Console.Clear();
            }

        }

        public List<List<int>> showTwoNumberEqualsResult(List<int> input, int expectedResult)
        {
            // Grouping Inputan Terlebih Dahulu
            input = input.GroupBy(x=>x).Select(x=>x.Key).ToList();

            // Mencatat untuk setiap number yang sudah dilewati oleh loop
            var passedListNumber = new List<int>();



            var result = new List<List<int>>();

            // The party begin
            input.ForEach(x =>
            {
                var pairNumber = expectedResult - x;

                if (passedListNumber.Where(x=>x.Equals(pairNumber)).Any())
                {

                    var equalsNumber = new List<int>();
                    var smaller = pairNumber < x ? pairNumber : x;
                    var greater = pairNumber > x ? pairNumber : x;
                    equalsNumber.AddRange(new int[] { smaller, greater });
                    result.Add(equalsNumber);
                }
                else
                {
                    passedListNumber.Add(x);
                }

            });


            return result;
        }

    }

}