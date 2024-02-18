using MasterDetails_Repo.DbModel;
using MasterDetails_Repo.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MasterDetails_Repo.Controllers
{
    public class FoodsController : Controller
    {
        private readonly IFoodRepo _foodRepo;

        public FoodsController(IFoodRepo foodRepo)
        {
            _foodRepo = foodRepo;
        }

        public IActionResult Index()
        {
            var updatedFoods = _foodRepo.GetAllFoodsWithOrders();
            return View(updatedFoods);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Food food)
        {
            _foodRepo.AddFood(food);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var food = _foodRepo.GetFoodById(id);
            return View(food);
        }

        [HttpPost]
        public IActionResult Edit(Food food)
        {
            _foodRepo.UpdateFood(food);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            _foodRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
