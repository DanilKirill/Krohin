using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WpfApp1.Model;

namespace WpfApp1.Data
{
    class TableList:ObservableCollection<Table>
    {
        k_kiri11Entities db = new k_kiri11Entities();
        public TableList()
        {
            foreach (var item in db.Table)
            {
                this.Add(item);
            }

        }
    }
}
