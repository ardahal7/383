namespace CMPS383_Phase1_Group4_Tables
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class DatabaseContext : DbContext
    {
        // Your context has been configured to use a 'UserContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CMPS383_Phase1_Group4_Tables.UserContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'UserContext' 
        // connection string in the application configuration file.
        public DatabaseContext() : base("name=DatabaseContext")
        {
            Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<InvItem> InvItems { get; set; }

    }

    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class InvItem
    {
        [Key]
        [Required]
        public int InvItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int StockQuantity { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}