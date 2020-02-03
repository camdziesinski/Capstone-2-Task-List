using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone2TaskList
{
    class Task
    {
        //  Team member’s name  2. Brief description  3. Due date  4. Whether it’s been completed or not

        private string employee, description;
        DateTime dueDate;
        bool completion;

        public string Employee
        {
            get { return employee; }
            set { employee = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }
        public bool Completion
        {
            get { return completion; }
            set { completion = value; }
        }









        public Task()

        {



        }



        public Task(string _employee, DateTime _dueDate, string _description, bool _completion)

        {

            employee = _employee;

            dueDate = _dueDate;

            description = _description;

            completion = _completion;



        }

        public static void DisplayTasks(List<Task> tasks)

        {
            Console.WriteLine("Employee\tDue Date\tTask\t\t\t\tStatus");
            for (int i = 1; i < tasks.Count + 1; i++)

            {



                if (tasks[i - 1].Completion)

                {

                    Console.Write($"{i}.{tasks[i - 1].Employee}\t{tasks[i - 1].DueDate}\t{tasks[i - 1].Description}\t\t");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("COMPLETED");
                    Console.ResetColor();
                }

                else

                {

                    Console.Write($"{i}.{tasks[i - 1].Employee}\t{tasks[i - 1].DueDate}\t{tasks[i - 1].Description}\t\t");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("UNCOMPLETED");
                    Console.ResetColor();
                }

            }

        }

    }
}