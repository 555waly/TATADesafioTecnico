using Microsoft.EntityFrameworkCore;

namespace TATADesafioTecnico.DataModelContext
{
    public class DataBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TipoCambioDb");
            //base.OnConfiguring(optionsBuilder);
        }

        public DbSet<DataModel.TipoCambioDataModel> TipoCambiosActual { get; set; }  
    }
}
