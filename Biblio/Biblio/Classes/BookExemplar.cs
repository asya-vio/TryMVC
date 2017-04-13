using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{    
    public class BookExemplar : Item
        {
            public int PublicationDate { get; set; }

            public BookExemplar(int date, int InventoryNumber)
            {              
                this.PublicationDate = date;
                Presence = presence.yes;
                this.InventoryNumber = InventoryNumber;
            }
        }
    }

