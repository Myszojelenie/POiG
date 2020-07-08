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
    class AssignmentVM:BaseVM
    {
        //properties do nazwy widocznego zadania
        private string _assignmentName;
        public string AssignmentName
        {
            get 
            {
                if (SelectedAssignment!=null)
	            {
                    _assignmentName=SelectedAssignment.Name;
                    return _assignmentName;
                }
                return "";
            }
        }

        //properties do przedmiotu widocznego zadania
        private string _subjectName;
        public string SubjectName
        {
            get 
            {
                if (SelectedAssignment!=null)
	            {
                    _subjectName=Studies.WhichSubject(SelectedAssignment).Name;
                    return _subjectName;
                }
                return "";
                
            }
        }

        //properties do listy zadanek widocznego zadania
        private ObservableCollection<Model.Task> _tasks;
        public ObservableCollection<Model.Task> Tasks
        {
            get
            {
                if (SelectedAssignment!=null)
	            {
                    _tasks = new ObservableCollection<Model.Task>();
                    for (int i = 0; i < SelectedAssignment.Tasks.Count; i++)
                    {
                        _tasks.Add(SelectedAssignment.Tasks[i]);
                    }
                   
                    return _tasks;
	            }
                return new ObservableCollection<Model.Task>();
                
            }

        }

        //properties do wybranego z listboxa zadanka
        private Model.Task _selectedTask;
        public Model.Task SelectedTask
        {
            set
            {
                _selectedTask=value;
            }
        }


        //properties do nazwy dodawanego zadanka
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

        //properties do informacji o zaliczeniu przemdiotu
        public string Status
        {
            get
            {
                if (SelectedAssignment!=null)
	            {
                    if (SelectedAssignment.Passed)
	                {
                        return "ZALICZONE";
	                }
                    return "NIE ZALICZONE";
	            }
                return "...";
            }
        }

        //properties do kolorku, w którym będzie się wyświetlać informacja o zaliczeniu zadania
        public System.Windows.Media.Brush ColorFunc
        {
            get
            {
                if (SelectedAssignment != null)
                {
                    if (SelectedAssignment.Passed)
                    {
                        return System.Windows.Media.Brushes.Green;
                    }
                    return System.Windows.Media.Brushes.Red;
                }
                return System.Windows.Media.Brushes.Black;

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
                            SelectedAssignment.AddTask(new Model.Task(TaskName)); //dodaje zadanko do widocznego zadania
                            TaskName=""; SelectedAssignment.Passed=false; Studies.WhichSubject(SelectedAssignment).Passed = false; //czyści textbox + usuwa ewentualne zaliczenie zadania i przedmiotu
                            onPropertyChanged(nameof(Tasks),nameof(TaskName),nameof(Status),nameof(ColorFunc));
                        },
                        arg => (!string.IsNullOrEmpty(TaskName))); // jeśli mamy coś wpisane w textboxa
                }

                return _addTask;
            }
        }

        //command do usuwania zadanka
        private ICommand _removeTask = null;

        public ICommand RemoveTask
        {
            get
            {
                if (_removeTask == null)
                {
                    _removeTask = new RelayCommand(
                        arg => {
                            SelectedAssignment.RemoveTask(SelectedAssignment.Tasks.IndexOf(_selectedTask)); //usuwa zadanko po wyszukaniu jego indeksu
                            onPropertyChanged(nameof(Tasks));
                        },
                        arg => (_selectedTask!=null )); //jeśli jest wybrane jakieś zadanko
                }

                return _removeTask;
            }
        }

        
        //command do buttona wykonującego zadanko
        private ICommand _accomplishTask = null;

        public ICommand AccomplishTask
        {
            get
            {
                if (_accomplishTask == null)
                {
                    _accomplishTask = new RelayCommand(
                        arg => {
                            SelectedAssignment.CompleteTask(SelectedAssignment.Tasks.IndexOf(_selectedTask)); //wykonuje zadanko po wyszukaniu jego indeksu
                            onPropertyChanged(nameof(Tasks));
                        },
                        arg => (_selectedTask!=null && !_selectedTask.IsCompleted)); //jeśli jest wybrane jakieś zadanko i nie jest ono jeszcze zaliczone
                }

                return _accomplishTask;
            }
        }

        //command do buttona wykonującego zadanie
        private ICommand _accomplishAssignment = null;

        public ICommand AccomplishAssignment
        {
            get
            {
                if (_accomplishAssignment == null)
                {
                    _accomplishAssignment = new RelayCommand(
                        arg => {
                            SelectedAssignment.Passed=true; //zalicza zadanie i wszystkie jego zadanka
                            SelectedAssignment.CompleteAllTasks();
                            onPropertyChanged(nameof(Tasks),nameof(Status),nameof(ColorFunc));
                        },
                        arg => ( !SelectedAssignment.Passed)); //jeśli zadanie nie jest ukończone
                }

                return _accomplishAssignment;
            }
        }
    }
}
