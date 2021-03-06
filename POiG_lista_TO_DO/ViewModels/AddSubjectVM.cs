﻿using System;
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
        //properties do nazwy dodawanego przedmiotu 
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


        //properties do prowadzącego dodawanego przedmiotu 
        public string Prowadzacy
        {
            get;set;
        }
        //properties do kierunku dodawanego przedmiotu 
        public string Kierunek
        {
            get;set;
        }

        //command do buttona dodającego przedmiot
        private ICommand _addSubject = null;

        public ICommand AddSubject
        {
            get
            {
                if (_addSubject == null)
                {
                    _addSubject = new RelayCommand(
                        arg => 
                        { 
                            Studies.Subjects.Add(new Subject(new List<Assignment>(),Nazwa,Kierunek,Prowadzacy)); //dodaje przedmiot z zadanymmi parametrami
                            Nazwa=""; //czyści wszystko
                            Prowadzacy="";
                            Kierunek="";
                            onPropertyChanged(nameof(Nazwa),nameof(Prowadzacy),nameof(Kierunek));
                        },
                        arg => 
                        (!string.IsNullOrEmpty(Nazwa) && //jeśli we wszystkie pola jest coś wpisane
                        !string.IsNullOrEmpty(Prowadzacy) && 
                        !string.IsNullOrEmpty(Kierunek)));
                }

                return _addSubject;
            }
        }

    }
}
