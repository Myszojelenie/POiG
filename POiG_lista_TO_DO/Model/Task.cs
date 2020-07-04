using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POiG_lista_TO_DO.Model
{
    public class Task
    {
        private string content;
        public string Content { get => content; set => content = value; }
        public bool IsCompleted { get; set; }

        public Task(string content)
        {
            this.content = content;
            IsCompleted = false;
        }
        public Task()
        {

        }
        public void CompleteTask()
        {
            if (IsCompleted == false)
            {
                IsCompleted = true;
            }
            else
            {
                Console.WriteLine("Zadanie zostało juz wykonane");
            }
        }
        public override string ToString()
        {
            return $"{content} {(IsCompleted ? "Wykonano" : "Jest do zrobienia")}";
        }
    }
}
