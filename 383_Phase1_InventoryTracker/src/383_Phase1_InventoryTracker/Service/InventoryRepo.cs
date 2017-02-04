using _383_Phase1_InventoryTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _383_Phase1_InventoryTracker.Service
{
    public class InventoryRepo 
    {
        private InventoryTrackerContext db = new InventoryTrackerContext();

        //Get

        public IEnumerable<InventoryItem> Get()
        {
            var InventoryItemsList = db.InventoryItems;
            return InventoryItemsList;
        }
    }
}
