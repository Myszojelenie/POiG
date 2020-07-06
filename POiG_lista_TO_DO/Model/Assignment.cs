using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POiG_lista_TO_DO.Model
{
    public class Assignment
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
        public override string ToString()
        {
            string result = $"{Name} Data: {Deadline}";
            //foreach (var item in Tasks)
            //{
            //    result += item.ToString();
            //    result += "\n";
            //}
            return result;
        }
    }
}
