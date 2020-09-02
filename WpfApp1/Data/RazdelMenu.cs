using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Data
{
    public class RazdelMenu:ObservableCollection<Sections>
    {
        k_kiri11Entities db = new k_kiri11Entities();
        public RazdelMenu()
        {
            foreach (var item in db.Sections)
            {
                this.Add(item);
            }

        
        
        }


    }
}
