using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace POiG_lista_TO_DO.ViewModels
{
    public class HomeVM : BaseVM
    {
        
        private List<string> _listOfAssignments;
        public ObservableCollection<string> ListOfAssignments
        {
            get
            {
                ObservableCollection<string> result= new ObservableCollection<string>();
                if (_listOfAssignments != null)
                {
                    foreach (string item in _listOfAssignments)
                    {
                        result.Add(item);
                    }
                }
                Console.WriteLine("dodano");
                return result;
            }
        }
        public HomeVM(List<string> listOfAssignments)
        {
            _listOfAssignments = listOfAssignments;
        }
    }
}
