using _383_Phase1_InventoryTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _383_Phase1_InventoryTracker.Service
{
    interface InventoryInterface
    {
        
        
            IEnumerable<InventoryItem> Get();
            InventoryItem GetInventory(int id);
            void PostFootballers(InventoryItem inventory);
            void Put(InventoryItem inventory);
        }
    }

