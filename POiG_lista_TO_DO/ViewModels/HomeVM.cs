using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using POiG_lista_TO_DO.Model;
namespace POiG_lista_TO_DO.ViewModels
{
    public class HomeVM : BaseVM
    {
        private Studies _studies;
        private List<string> _listOfAssignments ;
        public ObservableCollection<Assignment> ListOfAssignments
        {
            get
            {
               ObservableCollection<Assignment> result= new ObservableCollection<Assignment>();

               
                    foreach (var item in _studies.GenerateListOfAssignments())
                    {
                        result.Add(item);
                       // Console.WriteLine(item);
                    }
               
                //Console.WriteLine("dodano");
                //return result;
                return result;
            }
        }
       public ObservableCollection<Subject>Subjects
        {
            get
            {
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();


                foreach (var item in _studies.Subjects)
                {
                    result.Add(item);
                    
                }

               
                return result;
            }
        }
        private Subject _selectedSubject;
        public Subject SelectedSubject
        {
            get
            {
                return _selectedSubject;
            }
            set
            {
                _selectedSubject = value;
                onPropertyChanged(nameof(SelectedSubjectInfo));
            }
        }
        public string SelectedSubjectInfo
        {
            get { 
                if (_selectedSubject == null) 
                { 
                    return ""; 
                }
                else
                {
                    return _selectedSubject.Info(); ;
                }
                }
        }
        public HomeVM(ref Studies studies)
        {
            Console.WriteLine(_studies);
            _studies = studies;
           
        }
    }
}
