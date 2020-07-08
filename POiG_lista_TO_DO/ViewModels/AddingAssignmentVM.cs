using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

using POiG_lista_TO_DO.Model;

using System.Windows.Input;

using POiG_lista_TO_DO.ViewModels.BaseClass;

namespace POiG_lista_TO_DO.ViewModels
{
    public class AddingAssignmentVM:BaseVM
    {
        //konstruktor, ustawia datę na kalendarzu
        public AddingAssignmentVM()
        {
            _deadline=DateTime.Today;
        }

        //properties daty
        private DateTime _deadline;
        public DateTime Deadline
        {
            get => _deadline;
            set => _deadline = value;
        }
        //properties nazwy zadania
        public string Name
        {
            get;set;
        }

        //properties wybranego przedmioty w comboboxu
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
            }
        }

        //properties listy zadanek widocznej w listboxie
        private ObservableCollection<Model.Task> _tasks=new ObservableCollection<Model.Task>();
        public ObservableCollection<Model.Task> Tasks
        {
            get
            {
                return _tasks;
            }
            set
            {
                _tasks = value;
            }

        }

        //properties wybranego zadanka z listboxa
        private Model.Task _selectedTask;
        public Model.Task SelectedTask
        {
            set
            {
                _selectedTask=value;
            }
        }

        //properties nazwy dodawanego zadanka
        private string _taskName;
        public string TaskName
        {
            get 
            {
                return _taskName;
            }
            set 
            {   
                _taskName=value; 
            }
        }


        //command do buttona dodającego zadanko
        private ICommand _addTask = null;

        public ICommand AddTask
        {
            get
            {
                if (_addTask == null)
                {
                    _addTask = new RelayCommand(
                        arg => {
                            Tasks.Add(new Model.Task(TaskName)); //dodaje zadanko do listy + czyści textboxa
                            TaskName="";
                            onPropertyChanged(nameof(Tasks),nameof(TaskName));
                        },
                        arg => (!string.IsNullOrEmpty(TaskName))); //jeśli jest coś zapisane w textboxie
                }

                return _addTask;
            }
        }

        //command do buttona usuwającego zadanko
        private ICommand _removeTask = null;

        public ICommand RemoveTask
        {
            get
            {
                if (_removeTask == null)
                {
                    _removeTask = new RelayCommand(
                        arg => {
                            _tasks.Remove(_selectedTask); //usuwa i aktualizuje listę
                            onPropertyChanged(nameof(Tasks));
                        },
                        arg => (_selectedTask!=null)); //jesli jest wybrane jakieś zadanko
                }

                return _removeTask;
            }
        }




        //command do buttona dodającego zadanie
        private ICommand _addAssignment = null;

        public ICommand AddAssignment
        {
            get
            {
                if (_addAssignment == null)
                {
                    _addAssignment = new RelayCommand(
                        arg => {
                            SelectedSubject.AddAssignment(new Assignment(Studies.TaskToList(Tasks),Name,Deadline)); //dodaje zadanie z wprowadzonymi argumentami
                            Name="";  //czyści wszystko
                            _tasks=new ObservableCollection<Model.Task>(); 
                            Deadline=DateTime.Today; TaskName=""; SelectedSubject.Passed = false; //skoro dodane nowe zadanie, to trzeba zmienić ewentualne zaliczenie przedmiotu
                            onPropertyChanged(nameof(Name),nameof(Tasks),nameof(Deadline),nameof(TaskName));
                        },
                        arg => ( !string.IsNullOrEmpty(Name)  && !(Deadline==null) ));
                }

                return _addAssignment;
            }
        }

        

    }
}
