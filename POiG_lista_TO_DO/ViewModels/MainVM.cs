using POiG_lista_TO_DO.ViewModels.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace POiG_lista_TO_DO.ViewModels
{
    public class MainVM:BaseVM
    {
		//lista viewmodeli
		protected List<BaseVM> viewModels = new List<BaseVM>() { new AddSubjectVM(), new HomeVM(), new AddingAssignmentVM(), new AssignmentVM() };
		// pole opisujące aktualnie wybrany widok
		private BaseVM _selectedVM = null;
		public BaseVM SelectedVM
		{
			get
			{
				if (_selectedVM == null)
				{
					_selectedVM = viewModels[1]; //domyślnie strona główna
				}
				return _selectedVM;
			}
			set
			{
				_selectedVM = value;
				onPropertyChanged(nameof(SelectedVM));
			}
		}
		
		//command do buttonów zmieniających widok
		private ICommand _changeView;

		public ICommand ChangeView
		{
			get
			{
				if (_changeView==null)
				{
					
					_changeView =  new RelayCommand(arg =>
					{
						if (arg.ToString()=="AddSubject") //w zależności od buttona mamy różne parametry
						{
							SelectedVM = viewModels[0];
						}
						else if (arg.ToString() == "Home")
						{
							SelectedVM = viewModels[1];
						}	
						else if (arg.ToString() == "AddTask")
						{
							SelectedVM = viewModels[2];
						}
						
					},
					arg => true);
								
				}
				return _changeView;
			}
			
		}



		//specjalny command dla ostatniego buttona
		private ICommand _changeViewForTask;

		public ICommand ChangeViewForTask
		{
			get
			{
				if (_changeViewForTask==null)
				{
					
					_changeViewForTask =  new RelayCommand(arg =>
					{
						SelectedVM = viewModels[3];
					},
					arg =>_selectedAssignment!=null //button ma być odblokowany tylko, gdy wybrano jakieś zadanie
					);
							
				}
				return _changeViewForTask;
			}
			
		}




		//command zapisujący wprowadzone zmiany do pliku po zamknięciu okna
		private ICommand _save = null;
		public ICommand SaveCommand
		{
			get
			{
				if (_save == null)
				{
					_save = new RelayCommand(
					arg =>
					{
						Model.Serialization.Serialize("studia.xml",Studies);
					},
					arg => true
					);
				}
				return _save;
			}
		}

				

	}
}
