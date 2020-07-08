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



        private ICommand _addTask = null;

        public ICommand AddTask
        {
            get
            {
                if (_addTask == null)
                {
                    _addTask = new RelayCommand(
                        arg => {
                            SelectedAssignment.AddTask(new Model.Task(TaskName)); 
                            TaskName=""; SelectedAssignment.Passed=false; Studies.WhichSubject(SelectedAssignment).Passed = false;
                            onPropertyChanged(nameof(Tasks),nameof(TaskName),nameof(Status),nameof(ColorFunc));
                        },
                        arg => (!string.IsNullOrEmpty(TaskName) && SelectedAssignment!=null));
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
                            SelectedAssignment.RemoveTask(SelectedAssignment.Tasks.IndexOf(_selectedTask));
                            onPropertyChanged(nameof(Tasks));
                        },
                        arg => (_selectedTask!=null && SelectedAssignment!=null));
                }

                return _removeTask;
            }
        }

        

        private ICommand _accomplishTask = null;

        public ICommand AccomplishTask
        {
            get
            {
                if (_accomplishTask == null)
                {
                    _accomplishTask = new RelayCommand(
                        arg => {
                            SelectedAssignment.CompleteTask(SelectedAssignment.Tasks.IndexOf(_selectedTask));
                            onPropertyChanged(nameof(Tasks));
                        },
                        arg => (_selectedTask!=null && SelectedAssignment!=null && !_selectedTask.IsCompleted));
                }

                return _accomplishTask;
            }
        }

        
        private ICommand _accomplishAssignment = null;

        public ICommand AccomplishAssignment
        {
            get
            {
                if (_accomplishAssignment == null)
                {
                    _accomplishAssignment = new RelayCommand(
                        arg => {
                            SelectedAssignment.Passed=true;
                            SelectedAssignment.CompleteAllTasks();
                            onPropertyChanged(nameof(Tasks),nameof(Status),nameof(ColorFunc));
                        },
                        arg => (SelectedAssignment!=null && !SelectedAssignment.Passed));
                }

                return _accomplishAssignment;
            }
        }
    }
}
