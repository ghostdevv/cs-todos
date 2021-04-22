using System;
using System.Threading.Tasks;

namespace todos
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string response = "";

            do
            {
                Console.WriteLine();
                Console.WriteLine("1. View todos");
                Console.WriteLine("2. View specific todo");
                Console.WriteLine("9. Exit");

                response = GetString("");

                switch (response)
                {
                    case "1":
                        await Methods.ViewTodos();
                        break;
                    case "2":
                        await Methods.ViewTodo();
                        break;
                }
            }
            while (response != "9");
        }

        static public string GetString(string question)
        {
            Console.Write(question + "\n> ");
            return Console.ReadLine();
        }

        static public string StringifyBool(bool x)
        {
            return x ? "✔️" : "x";
        }
    }
}
