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

            public BookExemplar( int InventoryNumber, string Presence, int date) : base(InventoryNumber,  Presence)
            {              
                this.PublicationDate = date;
            }
        }
    }

