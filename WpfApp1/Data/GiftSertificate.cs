using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.Data
{
    class GiftSertificate:ObservableCollection<Model.GiftSertificate>
    {
        k_kiri11Entities db = new k_kiri11Entities();
        public GiftSertificate()
        {
            foreach (var item in db.GiftSertificate)
            {
                if(item.Status!="Unused")
                this.Add(item);
            }
        
        
        }
    }
}
