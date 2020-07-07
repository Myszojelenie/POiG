using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

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
        public static Studies StudiesFromFile(string pathToFile)
        {
            XmlSerializer xss = new XmlSerializer(typeof(Studies));
            
            Studies studies;
            using (Stream s = File.OpenRead(pathToFile))
                studies = (Studies)xss.Deserialize(s);
            return studies;
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
            result.Sort();
            return result;
        }
        public void RemoveAssignment(Assignment assignment)
        {
            foreach (var subject in subjects)
	        {
                if (subject.Assignments.Contains(assignment))
	            {
                    subject.Assignments.Remove(assignment);
	            }

	        }
        }
        public void RemoveSubject(Subject subject)
        {
            subjects.Remove(subject);
        }

        //public List<Subject> ListOfSubjects()
        //{
        //    List<string> result = new List<string>();
        //    foreach (var item in Subjects)
        //    {
        //        result.Add(item.Name);
        //    }
        //    return result;
        //}
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

        public ObservableCollection<Assignment> ListOfAssignmentsOC()
        {
            ObservableCollection<Assignment> result= new ObservableCollection<Assignment>();

            foreach (var item in GenerateListOfAssignments())
            {
                result.Add(item);
            }
            return result;
        }

        public ObservableCollection<Subject> SubjectsOC()
        {
            ObservableCollection<Subject> result = new ObservableCollection<Subject>();

            foreach (var item in Subjects)
            {
                result.Add(item);
            }
           
            return result; 
        }

        public List<Task> TaskToList(ObservableCollection<Task> tasks)
        {
            List<Task> result=new List<Task>();
            foreach (var item in tasks)
            {
                result.Add(item);
            }
            return result; 
        }

        public Subject WhichSubject(Assignment assignment)
        {
            foreach (var subject in subjects)
	        {
                if (subject.Assignments.Contains(assignment))
	            {
                    return subject;
	            }
	        }
            return new Subject();

        }
        private Dictionary<Assignment, Subject> _assignmentsWithSubjects;
       [XmlIgnore()]
        public Dictionary<Assignment, Subject> AssignmentsWithSubjects
        {
            get
            {
                _assignmentsWithSubjects = new Dictionary<Assignment, Subject>();
                ObservableCollection<Assignment> assignmentsOC = ListOfAssignmentsOC();
                for (int i = 0; i < assignmentsOC.Count; i++)
                {
                    _assignmentsWithSubjects.Add(assignmentsOC[i], WhichSubject(assignmentsOC[i]));
                }
                return _assignmentsWithSubjects;
            }
        }
    }
}
