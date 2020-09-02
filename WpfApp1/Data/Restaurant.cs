using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Data
{
    class Restaurant:ObservableCollection<Restaurants>
    {
        k_kiri11Entities db = new k_kiri11Entities();

        public Restaurant()
        {
            var query = from item in db.Restaurants
                        select item;
            foreach (Restaurants item in query)
            {
                this.Add(item);
            }
        
        }
    }
}
