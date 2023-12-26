using AVladyslav.TaskPlanner.Domain.Logic;
using AVladyslav.TaskPlanner.Domain.Models.enums;
using AVladyslav.TaskPlanner.Domain.Models;


internal static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Вiтаємо у Task Planner!");

        // Accept user input for WorkItems
        var workItems = GetWorkItemsFromUser();

        // Create an instance of SimpleTaskPlanner and order the WorkItems
        var planner = new SimpleTaskPlanner();
        var orderedItems = planner.CreatePlan(workItems);

        // Display the ordered WorkItems
        Console.WriteLine("\nВпорядкованi справи:");
        foreach (var item in orderedItems)
        {
            Console.WriteLine(item.ToString());
        }
    }

    private static WorkItem[] GetWorkItemsFromUser()
    {
        Console.Write("\nВведiть кiлькiсть справ: ");
        if (!int.TryParse(Console.ReadLine(), out int itemCount) || itemCount <= 0)
        {
            Console.WriteLine("Невалiдний ввiд. Вихiд з програми.");
            Environment.Exit(1);
        }

        var workItems = new WorkItem[itemCount];

        for (var i = 0; i < itemCount; i++)
        {
            Console.WriteLine($"\nСправа {i + 1}:");

            Console.Write("Назва: ");
            var title = Console.ReadLine();

            Console.Write("Термiн виконання (dd.MM.yyyy): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out var dueDate))
            {
                Console.WriteLine("Невалiдний формат дати. Вихiд з програми.");
                Environment.Exit(1);
            }

            Console.Write("Прiорiтет (None, Low, Medium, High, Urgent): ");
            if (!Enum.TryParse<Priority>(Console.ReadLine(), true, out var priority))
            {
                Console.WriteLine("Невалiдний прiорiтет. Вихiд з програми.");
                Environment.Exit(1);
            }

            Console.Write("Складнiсть (None, Minutes, Hours, Days, Weeks): ");
            if (!Enum.TryParse<Complexity>(Console.ReadLine(), true, out var complexity))
            {
                Console.WriteLine("Невалiдна cкладнiсть. Вихiд з програми.");
                Environment.Exit(1);
            }

            workItems[i] = new WorkItem
            {
                Title = title,
                DueDate = dueDate,
                Priority = priority,
                Complexity = complexity
            };
        }

        return workItems;
    }
}