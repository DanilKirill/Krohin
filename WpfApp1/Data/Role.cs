using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
namespace WpfApp1.Data
{
    class Role:ObservableCollection<Roles>
    {
        k_kiri11Entities db = new k_kiri11Entities();

        public Role()
        {
            var queryRole =
                from Roles in db.Roles
                select Roles;
            foreach (Roles item in queryRole)
            {
                this.Add(item);
            }
            
        }


    }
}
