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
   public class BaseVM:BaseClass.ViewModelBase //baza, każdy VM korzysta z niej
    {
        private static Model.Studies _studies = Model.Serialization.Deserialize("studia.xml"); //odczytujemy z pliku, tworząc instancję klasy studia
        public Model.Studies Studies { get => _studies; } //properties

        //properties do listy wszystkich zadań 
        public ObservableCollection<Assignment> ListOfAssignments
        {
            get
            {
                return _studies.Assignments();
            }
        }
        //properties dolisty wszystkich przedmiotów 
       public ObservableCollection<Subject> Subjects
        {
            get
            {
                return _studies.SubjectsOC();
            }
        }
        //properties do listy zadań z uwzględnionymi przedmiotami
        public Dictionary<Assignment,Subject> AssignmentsWithSubjects
        {
            get => _studies.AssignmentsWithSubjects;
        }
        //properties do wybranego zadania z list (prawej i lewej jednocześnie)
        protected static Assignment _selectedAssignment=null;
        public Assignment SelectedAssignment { get => _selectedAssignment; set => _selectedAssignment = value; }




    }
}
