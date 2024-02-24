using FactoryPatternDemo.Models;
using FactoryPatternDemo.ViewModel;
using Microsoft.AspNetCore.Mvc;
using FactoryPatternDemo.Models;
using FactoryPatternDemo.Factory;
using Microsoft.AspNetCore.Authorization;

namespace FactoryPatternDemo.Controllers
{
    
    public class ZooController : Controller
    {
        private readonly ILogger<ZooController> _logger;
        private readonly AnimalFactory _animalFactory;
        public ZooController(ILogger<ZooController> logger, AnimalFactory animalFactory)
        {
            _logger = logger;
            _animalFactory = animalFactory;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var animals = await _animalFactory.GetAllAnimals();
            return View(animals);
            //var animals = (await _animalFactory.GetAllAnimals())
            //    .Select(a => new AnimalViewModel { Id = a.Id, Type = a.GetType().Name })
            //    .ToList();
            //return View(animals);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnimalViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _animalFactory.CreateAnimal(model.Type);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return PartialView("Error");
                }
               
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var animal = await _animalFactory.GetAnimalById(id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AnimalViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _animalFactory.UpdateAnimal(model); // Pass the entire model
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var animal = await _animalFactory.GetAnimalById(id);
            if (animal == null)
            {
                return NotFound();
            }

            await _animalFactory.DeleteAnimal(id);
            return RedirectToAction(nameof(Index));
        }
    }

}

