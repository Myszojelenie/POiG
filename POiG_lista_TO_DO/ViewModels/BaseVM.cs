using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POiG_lista_TO_DO.ViewModels
{
    public class BaseVM : BaseClass.ViewModelBase
    {
        private static Model.Studies _studies = Model.Serialization.Deserialize("studia.xml");
        public Model.Studies Studies { get => _studies; }

    }
		
}
