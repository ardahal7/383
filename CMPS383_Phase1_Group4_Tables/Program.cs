using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CMPS383_Phase1_Group4_Tables
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseOps mainDBOps = new DatabaseOps();
            mainDBOps.insertDummyData();
        }
    }

    public class DatabaseOps
    {
        public void insertDummyData()
        {
            User dummyUser = new CMPS383_Phase1_Group4_Tables.User();
            dummyUser.UserId = 0;
            dummyUser.Name = "John Doe";

            InvItem dummyItem = new InvItem();
            dummyItem.InvItemId = 0;
            dummyItem.Name = "Rubber Dragon Dongers";
            dummyItem.StockQuantity = 9001;

            DatabaseContext dbc = new DatabaseContext();
            dbc.Users.Add(dummyUser);
            dbc.InvItems.Add(dummyItem);
            dbc.SaveChanges();
        }
    }

}
