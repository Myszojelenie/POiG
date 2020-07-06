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
    public class DodawanieZadaniaVM:BaseVM
    {
        public DodawanieZadaniaVM()
        {
            _deadline=DateTime.Today;
        }

        private DateTime _deadline;
        public DateTime Deadline
        {
            get => _deadline;
            set => _deadline = value;
        }

        public string Name
        {
            get;set;
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
            }
        }

        private ObservableCollection<Model.Task> _tasks=new ObservableCollection<Model.Task>();
        public ObservableCollection<Model.Task> Tasks
        {
            get
            {
                return _tasks;
            }

        }


        private Model.Task _selectedTask;
        public Model.Task SelectedTask
        {
            set
            {
                _selectedTask=value;
            }
        }

        private string _taskName;
        public string TaskName
        {
            get {
                return _taskName;
            }
            set 
            {   
                _taskName=value; 
            }
        }


        private ICommand _addTask = null;

        public ICommand AddTask
        {
            get
            {
                if (_addTask == null)
                {
                    _addTask = new RelayCommand(
                        arg => {
                            _tasks.Add(new Model.Task(TaskName)); 
                            TaskName="";
                            onPropertyChanged(nameof(Tasks),nameof(TaskName));
                        },
                        arg => (!string.IsNullOrEmpty(TaskName)));
                }

                return _addTask;
            }
        }


        private ICommand _removeTask = null;

        public ICommand RemoveTask
        {
            get
            {
                if (_removeTask == null)
                {
                    _removeTask = new RelayCommand(
                        arg => {
                            _tasks.Remove(_selectedTask);
                            onPropertyChanged(nameof(Tasks));
                        },
                        arg => (_selectedTask!=null));
                }

                return _removeTask;
            }
        }


       


        private ICommand _addAssignment = null;

        public ICommand AddAssignment
        {
            get
            {
                if (_addAssignment == null)
                {
                    _addAssignment = new RelayCommand(
                        arg => {
                            SelectedSubject.AddAssignment(new Assignment(Studies.TaskToList(Tasks),Name,Deadline));
                            Name="";  _tasks=new ObservableCollection<Model.Task>(); Deadline=DateTime.Today; TaskName="";
                            onPropertyChanged(nameof(Name),nameof(Tasks),nameof(Deadline),nameof(TaskName));
                        },
                        arg => ( !string.IsNullOrEmpty(Name)  && !(Deadline==null) ));
                }

                return _addAssignment;
            }
        }

        

    }
}
