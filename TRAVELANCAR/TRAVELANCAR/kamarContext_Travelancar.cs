using System.Data.Entity;
using TRAVELANCAR.Models;

namespace TRAVELANCAR
{
    public class kamarContext_Travelancar : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<TRAVELANCAR.kamarContext_Travelancar>());

        public kamarContext_Travelancar() : base("name=kamarContext_Travelancar")
        {
        }

        public DbSet<kamar_univ> kamar_univ { get; set; }
    }
}
