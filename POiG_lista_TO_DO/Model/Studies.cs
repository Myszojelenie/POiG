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
        //properties do listy przedmiotów (listy obiektów klasy Subject)
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
        //konstruktory
        public Studies(List<Subject> subjects)
        {
            this.subjects = subjects;
        }
        public Studies()
        {

        }
      
        //metoda generująca wszystkie niezdane zadania w formie List
        public List<Assignment> GenerateListOfAssignments()
        {
            List<Assignment> result = new List<Assignment>();
            foreach (var subject in subjects)
            {
                foreach (var assignment in subject.Assignments)
                {
                    if (!assignment.Passed)
                    {
                        result.Add(assignment);
                    }
                    
                }
            }
            result.Sort();
            return result;
        }
        //usuwa zadanie z listy wszystkich zadań 
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

        //properties do listy wszystkich niezdanych zadań w formie ObservableCollection
        public ObservableCollection<Assignment> Assignments
        { 
            get 
            {
                ObservableCollection<Assignment> result = new ObservableCollection<Assignment>();

                foreach (var item in GenerateListOfAssignments())
                {
                    result.Add(item);
                }
                return result;
            }
        }


        //metoda przekształcająca ObservableCollection w List
        public List<Task> TaskToList(ObservableCollection<Task> tasks)
        {
            List<Task> result=new List<Task>();
            foreach (var item in tasks)
            {
                result.Add(item);
            }
            return result; 
        }

        //metoda wyznaczająca przedmiot, do którego należy zadanie
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

        //lista do wyświetlania zadań z nazwą przedmiotów w nadchodzących
        private Dictionary<Assignment, Subject> _assignmentsWithSubjects;
       [XmlIgnore()]
        public Dictionary<Assignment, Subject> AssignmentsWithSubjects
        {
            get
            {
                _assignmentsWithSubjects = new Dictionary<Assignment, Subject>();
                
                for (int i = 0; i < Assignments.Count; i++)
                {
                    _assignmentsWithSubjects.Add(Assignments[i], WhichSubject(Assignments[i]));
                }
                return _assignmentsWithSubjects;
            }
        }
    }
}
