using System;
using System.Collections.Generic;

namespace Capstone2TaskList
{
    class Program
    {
        static void Main(string[] args)
        {


            List<Task> tasklist = new List<Task>

            {
                new Task("Cam",DateTime.Parse("3/6/2020"),"Clean Office for party",false),

                new Task("Jake",DateTime.Parse("2/13/2020"),"Organize invitations", true),

                new Task("Leo",DateTime.Parse("1/30/2020"),"Gather DJ equipment",true),

                new Task("Carly",DateTime.Parse("2/25/2020"),"Order catering service",false)
            };



            Console.WriteLine("Welcome");
            while (true)
            {
                PrintMenu();
                int input = GetUserNumberRange("Select from the menu by choosing", 1, 5);
                switch (input)
                {
                    case 1:
                        // extended portion
                        //PrintTaskListMenu();
                        // input = GetUserNumberRange("Select from the menu by choosing", 1, 5);
                        //switch (input)
                        //{
                        //    case 1:
                                Task.DisplayTasks(tasklist);
                        //        break;
                        //    case 2:
                        //        break;
                        //    case 3:
                        //        break;
                        //    case 4:
                        //        break;
                        //    case 5:
                        //        //exits back to main
                        //        break;
                        //}
                        break;
                    case 2:
                        AddTask();
                        break;
                    case 3:
                        Task.DisplayTasks(tasklist);
                        DeleteTask(tasklist);
                        break;
                    case 4:
                        Task.DisplayTasks(tasklist);
                        TaskCompleted(tasklist);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;

                }
            }
        }

        // Display a message and return user's input
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static int GetUserNumberRange(string message, int num1, int num2)
        {
            int Number = -1;
            do
            {
                Console.WriteLine($"{message} {num1} through {num2}");
                try
                {
                    Number = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input. Must be a number");
                }
                
            }
            while (!(Number >= num1 && Number <= num2));
            return Number;

        }

        // returns bool for one or the other.
        public static bool AnswerYesOrNO(string message, string yes, string no)
        {
            string input = GetUserInput($"{message}? [{yes}/{no}]").ToLower();

            while (input != yes && input != no)
            {
                Console.WriteLine($"Please enter [{yes}/{no}].");
                input = Console.ReadLine();
            }
            if (input == yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static void PrintTaskListMenu()
        {
            Console.WriteLine(
              $"\t1. Display tasks\n\t" +
                $"2. Display by team member\n\t" +
                $"3. Display by deadline\n\t" +
                $"4. Edit tasks\n\t" +
                 "5. Quit");
        }

        public static void PrintMenu()
        {
            Console.WriteLine(
              $"\t1. List task\n\t" +
                $"2. Add task\n\t" +
                $"3. Delete task\n\t" +
                $"4. Mark task complete\n\t" +
                 "5. Quit");
        }

        // 2. Add task
        public static Task AddTask()

        {

            string taskName = GetUserInput("Empoyee Name: ");
            bool truedate = false;
            DateTime dueDate = DateTime.Parse("1/1/2020");
            do
            {
                try
                {
                    dueDate = DateTime.Parse(GetUserInput("Due Date [mm/dd/yyyy]: "));
                    truedate = true;
                }
                catch
                {
                    Console.WriteLine("Invalid date format. Please enter a date. [mm/dd/yyyy]");
                }
            }
            while (truedate);
            string description = GetUserInput("Description: ");

            bool completed = false;



            Task newTask = new Task(taskName, dueDate, description, completed);

            return newTask;



        }
        // 3. Delete task
        public static void DeleteTask(List<Task> tasks)

        {
            bool sure;
            if (tasks.Count > 0)
            {

                int userNumber = GetUserNumberRange("Which task would you like to remove? Please select", 1, tasks.Count);
                int i = userNumber - 1;
                sure = AnswerYesOrNO("Are you sure you want to delete this task?", "y", "n");
                if (sure)
                {
                    tasks.RemoveAt(i);
                }
                
            }
            else
            {
                Console.WriteLine("there are no tasks to delete.");
            }
        }


        public static void TaskCompleted(List<Task> tasks)
        {
            int i = 0;
            bool complete = false;
            bool sure;
            while (!complete)
            {


                try
                {
                    i = int.Parse(GetUserInput("Which task would you like to mark completed?"));
                    sure = AnswerYesOrNO("Are you sure you want to mark this task completed?", "y", "n");
                    if (sure)
                    {
                        tasks[i - 1].Completion = true;
                        complete = true;
                    }
                    else
                    {
                        complete = true;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }

    }
}
