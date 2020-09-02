using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Data
{
    class Bludo : ObservableCollection<Model.Menu>
    {
        k_kiri11Entities db = new k_kiri11Entities();
        public Bludo()
        {
            foreach (var item in db.Menu)
            {
                this.Add(item);
            }
        
        }
    }
}
