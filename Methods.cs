using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace todos
{
    class Methods
    {
        static HttpClient client = new HttpClient();

        static public async Task ViewTodos()
        {
            string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos");
            Todo[] todos = JsonSerializer.Deserialize<Todo[]>(response);

            foreach (Todo todo in todos)
            {
                Console.WriteLine($"[{todo.id}][{Program.StringifyBool(todo.completed)}] {todo.title}");
            }
        }

        static public async Task ViewTodo()
        {
            int id;

            bool parsed = Int32.TryParse(
                Program.GetString("\nWhat is the id of the todo?"),
                out id
            );

            try
            {
                if (parsed)
                {
                    string response = await client.GetStringAsync($"https://jsonplaceholder.typicode.com/todos/{id}");
                    Todo todo = JsonSerializer.Deserialize<Todo>(response);

                    Console.WriteLine($"\nID: {todo.id} | Completed: {Program.StringifyBool(todo.completed)}\n{new String('=', 20)}");
                    Console.WriteLine(todo.title);
                }
                else
                {
                    Console.WriteLine("Invalid id");
                };
            }
            catch
            {
                Console.Write("\nThere was an error getting this todo, it was most likely an invalid ID.\n");
            }
        }
    }
}