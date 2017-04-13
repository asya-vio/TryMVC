using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public abstract class Item
    {
        public enum presence { no, yes }
   
        public presence Presence { get; set; }

        public int InventoryNumber;

        public Item(int inventoryNumber, string Presence)
        {
            this.InventoryNumber = inventoryNumber;
            this.Presence = (presence) Enum.Parse(typeof(presence), Presence);
        }

    }
}
