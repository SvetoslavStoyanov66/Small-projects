using System;
using System.Collections.Generic;

internal class Program
{
    private const string AddTaskCommand = "T";
    private const string MoveInProgressCommand = "I";
    private const string MoveCompletedCommand = "C";

    private static void Main(string[] args)
    {
        List<string> ToDo = new List<string>();
        List<string> InProgress = new List<string>();
        List<string> Completed = new List<string>();

        while (true)
        {
            Console.Clear();
            DisplayTable(ToDo, InProgress, Completed);
            DisplayOptions();
            string userInput = Console.ReadLine().ToUpper();
            ProcessUserInput(userInput, ToDo, InProgress, Completed);
        }
    }

    private static void DisplayOptions()
    {
        Console.WriteLine("For entering tasks in 'To do' section write /T/");
        Console.WriteLine("For moving tasks to 'In Progress' section write /I/");
        Console.WriteLine("For moving tasks to 'Completed' section write /C/");
    }

    private static void DisplayTable(List<string> ToDo, List<string> InProgress, List<string> Completed)
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("|  To do  |In Progress|Completed|");
        Console.WriteLine("---------------------------------");

        int maxCount = Math.Max(Math.Max(ToDo.Count, InProgress.Count), Completed.Count);

        for (int i = 0; i < maxCount; i++)
        {
            string toDoTask = i < ToDo.Count ? ToDo[i] : "";
            string inProgressTask = i < InProgress.Count ? InProgress[i] : "";
            string completedTask = i < Completed.Count ? Completed[i] : "";

            Console.WriteLine($"|{toDoTask,-10}|{inProgressTask,-12}|{completedTask,-9}|");
        }

        Console.WriteLine("---------------------------------");
    }

    private static void ProcessUserInput(string input, List<string> ToDo, List<string> InProgress, List<string> Completed)
    {
        string nameOfTask = "";
        int index = 0;

        switch (input)
        {
            case AddTaskCommand:
                Console.WriteLine("Please enter the name of the task");
                nameOfTask = Console.ReadLine();
                ToDo.Add(nameOfTask);
                break;

            case MoveInProgressCommand:
                Console.WriteLine("Please write the name of the task you want to move");
                nameOfTask = Console.ReadLine();
                if (ToDo.Contains(nameOfTask))
                {
                    InProgress.Add(nameOfTask);
                    ToDo.Remove(nameOfTask);
                }
                else
                {
                    Console.WriteLine("Task not found in 'To do' section.");
                }
                break;

            case MoveCompletedCommand:
                Console.WriteLine("Please write the name of the task you want to move");
                nameOfTask = Console.ReadLine();
                if (InProgress.Contains(nameOfTask))
                {
                    Completed.Add(nameOfTask);
                    InProgress.Remove(nameOfTask);
                }
                else
                {
                    Console.WriteLine("Task not found in 'In Progress' section.");
                }
                break;

            default:
                Console.WriteLine("Please input a valid command.");
                break;
        }
    }
}
