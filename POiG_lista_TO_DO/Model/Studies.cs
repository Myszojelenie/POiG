using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POiG_lista_TO_DO.Model
{
    public class Studies
    {
        private List<Subject> subjects;
        public List<Subject> Subjects
        {
            get => subjects;
            set
            {
                if (subjects == null)
                {
                    subjects = value;
                }
            }
        }
        public Studies(List<Subject> subjects)
        {
            this.subjects = subjects;
        }
        public Studies()
        {

        }
        public List<Assignment> GenerateListOfAssignments()
        {
            List<Assignment> result = new List<Assignment>();
            foreach (var subject in subjects)
            {
                foreach (var assignment in subject.Assignments)
                {
                    result.Add(assignment);
                }
            }
            return result;
        }
        public override string ToString()
        {
            string result = "";
            foreach (var subject in subjects)
            {
                result += subject.Name;
                result += "\n";
                result += subject.ToString();
            }
            return result;
        }

    }
}
