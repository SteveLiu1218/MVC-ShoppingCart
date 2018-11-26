namespace ShoppingCartPractice.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CartsEntities : DbContext
    {
        public CartsEntities()
            : base("name=CartsEntities")
        {
        }

        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<ShoppingCartPractice.Models.ViewModel.ProductListViewModel> ProductListViewModels { get; set; }

        public System.Data.Entity.DbSet<ShoppingCartPractice.Models.ViewModel.LoginViewModel> LoginViewModels { get; set; }

        public System.Data.Entity.DbSet<ShoppingCartPractice.Models.ViewModel.MemberListViewModel> ManageMemberViewModels { get; set; }
    }
}
