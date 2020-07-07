using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using POiG_lista_TO_DO.Model;
using POiG_lista_TO_DO.ViewModels.BaseClass;

namespace POiG_lista_TO_DO.ViewModels
{
    class AddSubjectVM:BaseVM
    {
        private string _nazwa;
        public string Nazwa
        {
            get => _nazwa;
                
            set
            {
                _nazwa = value;
                onPropertyChanged(Nazwa);
            }
        }
        public string Prowadzacy
        {
            get;set;
        }
        public string Kierunek
        {
            get;set;
        }

        private ICommand _addSubject = null;

        public ICommand AddSubject
        {
            //nie podoba mi sie, że nie wykrywa od razu, że textbox juz cos w sobie ma, trzeba odklikac i zaklikać
            get
            {
                if (_addSubject == null)
                {
                    _addSubject = new RelayCommand(
                        arg => 
                        { 
                            Studies.Subjects.Add(new Subject(new List<Assignment>(),Nazwa,Kierunek,Prowadzacy)); 
                            Nazwa="";
                            Prowadzacy="";
                            Kierunek="";
                            onPropertyChanged(nameof(Nazwa),nameof(Prowadzacy),nameof(Kierunek));
                        },
                        arg => 
                        (!string.IsNullOrEmpty(Nazwa) &&
                        !string.IsNullOrEmpty(Prowadzacy) && 
                        !string.IsNullOrEmpty(Kierunek)));
                }

                return _addSubject;
            }
        }

    }
}
