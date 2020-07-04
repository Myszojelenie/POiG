using POiG_lista_TO_DO.ViewModels.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace POiG_lista_TO_DO.ViewModels
{
    public class MainVM:BaseVM
    {
		private BaseVM _selectedVM ;

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
							SelectedVM = new DodawaniePrzedmiotuVM();
						}
						else if (arg.ToString() == "Home")
						{
							SelectedVM = new HomeVM();
						}	
						else if (arg.ToString() == "AddTask")
						{
							SelectedVM = new DodawanieZadaniaVM();
						}	
						else if (arg.ToString() == "TaskView")
						{
							SelectedVM = new ZadanieVM();
						}	
						
					},
					arg => true);
								
				}
				return _changeView;
			}
			
		}
				

	}
}
