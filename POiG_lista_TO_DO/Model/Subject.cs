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
        private string _lecturer;

        public string Lecturer
        {
            get { return _lecturer; }
            set { _lecturer = value; }
        }
        private string _fieldOfStudy;

        public string FieldOfStudy
        {
            get { return _fieldOfStudy; }
            set { _fieldOfStudy = value; }
        }

        public Subject(List<Assignment> assignments, string name, string fieldOfStudy, string lecturer)
        {
            this.assignments = assignments;
            this.name = name;
            _fieldOfStudy = fieldOfStudy;
            _lecturer = lecturer;
        }
        public Subject()
        {

        }
        public string Info()
        {
            string result = $"{Name}\n{Lecturer}\n{FieldOfStudy}";
           
            return result;
        }
        public override string ToString()
        {
            
            return Name;
        }
    }
}
