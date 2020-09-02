using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WpfApp1.Model;

namespace WpfApp1.Data
{
    class Vxod:ObservableCollection<Model.Vxod>
    {
        k_kiri11Entities db = new k_kiri11Entities();

        public Vxod()
        {
            foreach (var item in db.Vxod)
            {
                Add(item);
            }
        
        }
    }
}
