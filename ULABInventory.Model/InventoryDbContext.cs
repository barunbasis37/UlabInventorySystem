using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABInventory.Model
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext() :base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<School> School { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Campus> Campus { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemDetail> ItemDetail { get; set; }
        public DbSet<CheckIn> CheckIn { get; set; }
        public DbSet<CheckInDetail> CheckInDetail { get; set; }
        public DbSet<Issue> Issue { get; set; }
        public DbSet<IssueDetail> IssueDetail { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Garbaged> Garbaged { get; set; }
        public DbSet<PurchaseBy> PurchaseBy { get; set; }
        public DbSet<Requisition> Requisition { get; set; }
        public DbSet<RequisitionDetail> RequisitionDetail { get; set; }
        public DbSet<Program> Program { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }
        public DbSet<IssueApproved> IssueApproveds { get; set; }

        //public DbSet<SubCategoryM> SubCategoryM { get; set; }
        //public DbSet<CategoryM> CategoryM { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

        //public System.Data.Entity.DbSet<ULABInventory.ViewModels.ItemDetailVM> ItemDetailVMs { get; set; }
    }
}
