using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POiG_lista_TO_DO.Model
{
    public class Subject
    {
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
        private List<Assignment> assignments;
        public List<Assignment> Assignments
        {
            get => assignments;
            set
            {
                if (assignments == null)
                {
                    assignments = value;
                }
            }
        }
        public Subject(List<Assignment> assignments, string name)
        {
            this.assignments = assignments;
            this.name = name;
        }
        public Subject()
        {

        }
        public override string ToString()
        {
            string result = "";
            foreach (var item in assignments)
            {
                result += item;
            }
            return result;
        }
    }
}
