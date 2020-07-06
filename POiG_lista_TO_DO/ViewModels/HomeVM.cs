using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using POiG_lista_TO_DO.Model;
using POiG_lista_TO_DO.ViewModels.BaseClass;

namespace POiG_lista_TO_DO.ViewModels
{
    public class HomeVM : BaseVM
    {
        
        private List<string> _listOfAssignments ;
        public ObservableCollection<Assignment> ListOfAssignments
        {
            get
            {
               ObservableCollection<Assignment> result= new ObservableCollection<Assignment>();

               
                    foreach (var item in base.Studies.GenerateListOfAssignments())
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


                foreach (var item in base.Studies.Subjects)
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
                onPropertyChanged(nameof(SelectedSubjectInfo),nameof(SelectedSubjectAssignments));
            }
        }
        public List<Assignment> SelectedSubjectAssignments
        {
            get
            {
                if (_selectedSubject == null)
                {
                    return null;
                }
                else
                {
                    return _selectedSubject.Assignments; 
                }
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
        private Assignment _selectedAssignment = null;
        public Assignment SelectedAssignment
        {
            get
            {
                return _selectedAssignment;
            }
            set
            {
                _selectedAssignment = value;
            }
        }
        private ICommand _changeView;

        public ICommand ChangeView
        {
            get
            {
                
                //if (_changeView == null)
                //{

                //    _changeView = new RelayCommand(arg =>
                //    {
                //        if (arg.ToString() == "AddSubject")
                //        {
                //            MainVM.SelectedVM = viewModels[0];
                //        }
                //        else if (arg.ToString() == "Home")
                //        {
                //            SelectedVM = viewModels[1];
                //        }
                //        else if (arg.ToString() == "AddTask")
                //        {
                //            SelectedVM = viewModels[2];
                //        }
                //        else if (arg.ToString() == "TaskView")
                //        {
                //            SelectedVM = viewModels[3];
                //        }

                //    },
                //    arg => true);

                //}
                return _changeView;
            }

        }
       
    }
}
