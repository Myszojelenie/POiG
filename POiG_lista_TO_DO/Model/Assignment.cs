using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace POiG_lista_TO_DO.Model
{
    public class Assignment:IComparable
    {
        private List<Task> tasks;
        private string name;
        public string Name
        {
            get => name; set
            {
                if (string.IsNullOrEmpty(name))
                {
                    name = value;
                }
            }
        }
        public List<Task> Tasks
        {
            get => tasks; set
            {
                if (tasks == null)
                {
                    tasks = value;
                }
            }
        }
        private bool _passed;
        public bool Passed
        {
            get
            { 
                return _passed;
            }
            set
            {
                _passed=value;
            }
        }
        private DateTime _deadline;
        public DateTime Deadline
        {
            get => _deadline;
            set => _deadline = value;
        }
        public Assignment(List<Task> tasks, string name, DateTime deadline)
        {
            this.tasks = tasks;
            this.name = name;
            _deadline = deadline;
            _passed=false;
        }
        public Assignment()
        {

        }
        public void AddTask(Task task)
        {
            tasks.Add(task);
        }
        public void RemoveTask(int number)
        {
            tasks.RemoveAt(number);
        }
        public void CompleteTask(int number)
        {
            tasks[number].CompleteTask();
        }

        public void CompleteAllTasks()
        {
            foreach (var item in Tasks)
            {
                item.CompleteTask();
            }
        }
        private string _convertIntToDateString(int a)
        {
            if (a<10)
            {
                return "0" + a.ToString();
            }
            else
            {
                return a.ToString();
            }
        }
      
        public override string ToString( )
        {
            string result = $"{Name}" +
                $" Data: {_convertIntToDateString(Deadline.Day)}." +
                $"{_convertIntToDateString(Deadline.Month)}" +
                $".{Deadline.Year}r. ";
            //foreach (var item in Tasks)
            //{
            //    result += item.ToString();
            //    result += "\n";
            //}
            return result;
        }
        public bool IsEmpty() => String.IsNullOrEmpty(Name) && Tasks == null;

       
        public int CompareTo(object obj)
        {
            Assignment a = (Assignment)obj;
            if (this.Deadline==a.Deadline)
            {
                return 0;
            }
            else if (this.Deadline > a.Deadline)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }


    }
}
