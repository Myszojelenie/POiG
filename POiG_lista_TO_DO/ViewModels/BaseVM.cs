using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using POiG_lista_TO_DO.ViewModels.BaseClass;

using POiG_lista_TO_DO.Model;

using System.Collections.ObjectModel;
namespace POiG_lista_TO_DO.ViewModels
{
   public class BaseVM:BaseClass.ViewModelBase
    {
        private static Model.Studies _studies = Model.Serialization.Deserialize("studia.xml");
        public Model.Studies Studies { get => _studies; }


        public ObservableCollection<Assignment> ListOfAssignments
        {
            get
            {

                return _studies.Assignments;
            }
        }
       public ObservableCollection<Subject> Subjects
        {
            get
            {
                ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
                foreach (var item in _studies.Subjects)
                {
                    subjects.Add(item);
                }
                return subjects;
            }
        }
        public Dictionary<Assignment,Subject> AssignmentsWithSubjects
        {
            get => _studies.AssignmentsWithSubjects;
        }
        protected static Assignment _selectedAssignment=null;
        public Assignment SelectedAssignment { get => _selectedAssignment; set => _selectedAssignment = value; }




    }
}
