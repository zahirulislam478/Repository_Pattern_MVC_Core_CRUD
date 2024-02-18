using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MasterDetails_Repo.DbModel 
{
    public class Food
    {
        public int FoodId { get; set; }

        [Required, StringLength(100)]
        public string FoodName { get; set; } = default!;

        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }

    public class Order
    {
        public int OrderId { get; set; } 

        [Required, StringLength(100)]
        public string CustomerName { get; set; } = default!;

        [Required, StringLength(100)]
        public string Phone { get; set; } = default!;

        [Required, DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        [Required, Column(TypeName = "money")]
        public decimal TotalAmount { get; set; } 

        public int FoodId { get; set; }
        public virtual Food Food { get; set; } = default!;
    }

    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }
        public DbSet<Food> Foods { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
    }
}