using POiG_lista_TO_DO.ViewModels.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace POiG_lista_TO_DO.ViewModels
{
    public class MainVM:BaseVM
    {
		private static Model.Studies _studies = new Model.Studies();
		public Model.Studies Studies { get=>_studies; }
		private BaseVM _selectedVM = new BaseVM();
		private List<BaseVM> viewModels = new List<BaseVM>() { new DodawaniePrzedmiotuVM(), new BaseVM(), new DodawanieZadaniaVM(), new ZadanieVM() };
		public MainVM()
		{
			
			_studies = Model.Studies.StudiesFromFile("studia.xml");
			Console.WriteLine(_studies);
			viewModels[1] = new HomeVM(ref _studies);
			_selectedVM = viewModels[1];
		}
		public BaseVM SelectedVM
		{
			get { return _selectedVM; }
			set 
			{ 
				_selectedVM = value;
				onPropertyChanged(nameof(SelectedVM));
			}
		}
		
		
		private ICommand _changeView;

		public ICommand ChangeView
		{
			get
			{
				if (_changeView==null)
				{
					
					_changeView =  new RelayCommand(arg =>
					{
						if (arg.ToString()=="AddSubject")
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
						else if (arg.ToString() == "TaskView")
						{
							SelectedVM = viewModels[3];
						}	
						
					},
					arg => true);
								
				}
				return _changeView;
			}
			
		}
				

	}
}
