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
       //properies do nazwy zadania
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
        //properties do listy zadanek
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
        //properties do informacji o zaliczeniu zadania
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
        //properties do daty zadania
        private DateTime _deadline;
        public DateTime Deadline
        {
            get => _deadline;
            set => _deadline = value;
        }
        //konstruktor, domyślnie zadanie jest niezaliczone
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
        //metoda pozwalająca zapisać datę w odpowiedniej postaci, użyta w ToString()
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
           
            return result;
        }
        

       //metoda porównująca deadline'y 2 zadań
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
