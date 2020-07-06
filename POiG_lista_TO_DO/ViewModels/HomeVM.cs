﻿using System;
using POiG_lista_TO_DO.ViewModels.BaseClass;
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
                onPropertyChanged(nameof(SelectedSubjectInfo),nameof(SelectedSubjectAssignments),nameof(PassedInfo));
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
        private ObservableCollection<Assignment> _selectedSubjectAssignments;
        public ObservableCollection<Assignment> SelectedSubjectAssignments
        {
            get
            {
                if (_selectedSubject!=null)
	            {
                    return _selectedSubject.AssignmentsOC();
	            }
                return new ObservableCollection<Assignment>();
                
            }
            set
            {
                _selectedSubjectAssignments = value;
                onPropertyChanged(nameof(ListOfAssignments),nameof(SelectedSubjectAssignments));
            }

        }

        public string PassedInfo
        {
            get
            {
                if (SelectedSubject!=null)
	            {
                    if (SelectedSubject.Passed)
	                {
                        return "TAK";
	                }
                    return "NIE";
	            }
                return "...";
            }
        }


        // usuwa, ale nie widac od razu
        private ICommand _removeAssignment = null;

        public ICommand RemoveAssignment
        {
            //do stworzenia obiektu polecenie użyjemy pomocniczej klasy RelayCommand
            get
            {
                if (_removeAssignment == null)
                {
                    _removeAssignment = new RelayCommand(
                        arg => {
                            Studies.RemoveAssignment(SelectedAssignment); 
                            if(SelectedSubject!=null)
                            { SelectedSubjectAssignments=SelectedSubject.AssignmentsOC(); 
                            }
                            onPropertyChanged(nameof(ListOfAssignments));
                        },
                        arg => (SelectedAssignment!=null));
                }

                return _removeAssignment;
            }
        }


         private ICommand _passSubject = null;

        public ICommand PassSubject
        {
            //do stworzenia obiektu polecenie użyjemy pomocniczej klasy RelayCommand
            get
            {
                if (_passSubject == null)
                {
                    _passSubject = new RelayCommand(
                        arg => {
                            SelectedSubject.Passed=true;
                            onPropertyChanged(nameof(PassedInfo));
                        },
                        arg => (SelectedSubject!=null && PassedInfo!="TAK"));
                }

                return _passSubject;
            }
        }


        private ICommand _removeSubject = null;

        public ICommand RemoveSubject
        {
            //do stworzenia obiektu polecenie użyjemy pomocniczej klasy RelayCommand
            get
            {
                if (_removeSubject == null)
                {
                    _removeSubject = new RelayCommand(
                        arg => {
                            Studies.RemoveSubject(SelectedSubject);
                            SelectedSubject=null;
                            onPropertyChanged(nameof(SelectedSubjectAssignments),nameof(SelectedSubjectInfo),nameof(Subjects),nameof(SelectedSubject));
                        },
                        arg => (SelectedSubject!=null));
                }

                return _removeSubject;
            }
        }
        

        

    }
}
