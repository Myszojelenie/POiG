using System;
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
        
        //properties do wybranego przedmoitu z comboboxa
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
                onPropertyChanged(nameof(SelectedSubjectInfo),nameof(SelectedSubjectAssignments),nameof(PassedInfo),nameof(ColorFunc));
            }
        }
        //properties do info o wybranym przedmiocie
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
        //properies do listy zadań z wybranego przedmiotu (wszystkich)
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
                onPropertyChanged(nameof(ListOfAssignments),nameof(SelectedSubjectAssignments), nameof(AssignmentsWithSubjects));
            }

        }

        //properties do informacji, czy przedmiot jest zaliczony 
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


        // command do buttona usuwającego zaznaczone zadanie
        private ICommand _removeAssignment = null;

        public ICommand RemoveAssignment
        {
            get
            {
                if (_removeAssignment == null)
                {
                    _removeAssignment = new RelayCommand(
                        arg => {
                            Studies.RemoveAssignment(SelectedAssignment);  //usuwa zadanie z listy wszystkich zadań
                            if(SelectedSubject!=null)
                            { SelectedSubjectAssignments=SelectedSubject.AssignmentsOC();  //jeślimamy wybrany jakiś przedmiot, to na nowo pobiera listę jego zadań
                            }
                        onPropertyChanged(nameof(ListOfAssignments), nameof(AssignmentsWithSubjects)
                                );
                        },
                        arg => (SelectedAssignment!=null)); //jeśli wybrano jakieś zadanie
                }

                return _removeAssignment;
            }
        }

        //command do buttona zaliczającego cały przedmiot
        private ICommand _passSubject = null;

        public ICommand PassSubject
        {
            get
            {
                if (_passSubject == null)
                {
                    _passSubject = new RelayCommand(
                        arg => {
                            SelectedSubject.Passed=true; //zalicza przedmiot i wszystkie jego zadanka, informuje odpowiednie pola
                            SelectedSubject.PassAllAssignments();
                            onPropertyChanged(nameof(PassedInfo),nameof(ColorFunc), nameof(ListOfAssignments), nameof(AssignmentsWithSubjects));
                        },
                        arg => (SelectedSubject!=null && PassedInfo!="TAK")); //jeśli jest wybrany jakiś przedmiot i nie jest jeszcze zaliczony
                }

                return _passSubject;
            }
        }

        //command do buttona usuwającego przedmiot
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
                            Studies.RemoveSubject(SelectedSubject); //usuwa przedmiot, usuwa zaznaczenie przedmiotu
                            SelectedSubject=null;
                            onPropertyChanged(nameof(SelectedSubjectAssignments),nameof(SelectedSubjectInfo),nameof(Subjects),nameof(SelectedSubject),nameof(AssignmentsWithSubjects));
                        },
                        arg => (SelectedSubject!=null)); //jeśli jakiś przedmiot jest zaznaczony
                }

                return _removeSubject;
            }
        }

        //properties do kolorku, w którym będzie wyświetlać się informacja o zaliczeniu przedmiotu
        public System.Windows.Media.Brush ColorFunc
        {
            get
            {
                if (SelectedSubject!=null)
                {
                    if (SelectedSubject.Passed)
                    {
                        return System.Windows.Media.Brushes.Green;
                    }
                    return System.Windows.Media.Brushes.Red;
                }
                return System.Windows.Media.Brushes.Black;

            }
        }



    }
}
