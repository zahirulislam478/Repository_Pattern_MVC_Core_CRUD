using MasterDetails_Repo.DbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterDetails_Repo.Repository
{
    public class FoodRepo : IFoodRepo
    {
        private readonly RestaurantDbContext _db;

        public FoodRepo(RestaurantDbContext db)
        {
            this._db = db;
        }

        public IEnumerable<Food> GetAllFoodsWithOrders()
        {
            return _db.Foods.Include(f => f.Orders).ToList();
        }

        public Food GetFoodById(int id)
        {
            return _db.Foods
                       .Include(f => f.Orders)
                       .FirstOrDefault(f => f.FoodId == id)
                       ?? throw new InvalidOperationException("Food not found");
        }

        public void AddFood(Food food)
        {
            _db.Foods.Add(food);
            _db.SaveChanges();
        }

        public void UpdateFood(Food food)
        {
            var existingFood = _db.Foods.Include(f => f.Orders).FirstOrDefault(f => f.FoodId == food.FoodId);
            if (existingFood != null)
            {
                existingFood.FoodName = food.FoodName;
                existingFood.Price = food.Price;

                var existingOrders = _db.Orders.Where(o => o.FoodId == food.FoodId);
                _db.Orders.RemoveRange(existingOrders);

                if (food.Orders != null)
                {
                    foreach (var order in food.Orders)
                    {
                        existingFood.Orders.Add(new Order
                        {
                            CustomerName = order.CustomerName,
                            Phone = order.Phone,
                            OrderDate = order.OrderDate,
                            TotalAmount = order.TotalAmount
                        });
                    }
                }

                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var food = _db.Foods.Find(id);
            if (food != null)
            {
                var orders = _db.Orders.Where(o => o.FoodId == id);
                _db.Orders.RemoveRange(orders);
                _db.Foods.Remove(food);
                _db.SaveChanges();
            }
        }
    }
}
