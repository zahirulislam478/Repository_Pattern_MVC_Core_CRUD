using MasterDetails_Repo.DbModel;
using System.Collections.Generic;

namespace MasterDetails_Repo.Repository
{
    public interface IFoodRepo
    {
        IEnumerable<Food> GetAllFoodsWithOrders();
        Food GetFoodById(int id);
        void AddFood(Food food);
        void UpdateFood(Food food);
        void Delete(int id);
    }
}
