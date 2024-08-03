using ChessApp.Models;

namespace ModelsUnitTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 7; i >= 0; i--)
            {
                for (int j = 0; j < 8; j++)
                {
                    Square s = new Square(i, j);
                    Console.Write(s.Name + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
