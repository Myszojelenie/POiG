using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;

namespace POiG_lista_TO_DO.Model
{
    public class Subject
    {
        private string name;
        //properties do nazwy przedmiotu
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

       //properties do listy zadań danego przedmiotu
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
        
        //properties do informacji o tym, czy przedmiot jest zaliczony
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

        private string _lecturer;
        //properties do prowaadzacego
        public string Lecturer
        {
            get { return _lecturer; }
            set { _lecturer = value; }
        }
        private string _fieldOfStudy;
        //properties do kierunku
        public string FieldOfStudy
        {
            get { return _fieldOfStudy; }
            set { _fieldOfStudy = value; }
        }
        //konstruktor, domyślnie przedmiot jest niezaliczony
        public Subject(List<Assignment> assignments, string name, string fieldOfStudy, string lecturer)
        {
            this.assignments = assignments;
            this.name = name;
            _fieldOfStudy = fieldOfStudy;
            _lecturer = lecturer;
            _passed=false;
        }
        public Subject()
        {

        }
        //metoda zwracająca info o przedmiocie
        public string Info()
        {
            string result = $"{Name}\n{Lecturer}\n{FieldOfStudy}";

            return result;
        }
        public override string ToString()
        {
            return Name;
        }
        //metoda zwracająca listę zadań przedmiotu w formie ObservableCollection
        public ObservableCollection<Assignment> AssignmentsOC()
        {
            ObservableCollection<Assignment> result= new ObservableCollection<Assignment>();
            foreach (var item in Assignments)
            {
                result.Add(item);
            }
            return result;
        }
        //metoda dodająca zadanie
        public void AddAssignment(Assignment assignment)
        {
            assignments.Add(assignment);
        }
        //metoda zaliczająca wszystkie zadania i ich zadanka
        public void PassAllAssignments()
        {
            foreach (var item in Assignments)
            {
                item.Passed = true;
                item.CompleteAllTasks();
            }
        }
    }
}
