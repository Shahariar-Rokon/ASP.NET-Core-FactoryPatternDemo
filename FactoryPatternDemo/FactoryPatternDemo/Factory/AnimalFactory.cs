using FactoryPatternDemo.DAL;
using FactoryPatternDemo.Models;
using FactoryPatternDemo.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace FactoryPatternDemo.Factory
{
    public class AnimalFactory
    {
        private readonly FactoryDBContext _context;

        public AnimalFactory(FactoryDBContext context)
        {
            _context = context;
        }

        public async Task<AnimalViewModel> CreateAnimal(string type)
        {
            Animal animal;
            switch (type)
            {
                case "Lion":
                    animal = new Lion();
                    break;
                case "Elephant":
                    animal = new Elephant();
                    break;
                default:
                    throw new ArgumentException("Invalid type", nameof(type));
            }

            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();

            return new AnimalViewModel { Id = animal.Id, Type = type };
        }

        public async Task<IEnumerable<AnimalViewModel>> GetAllAnimals()
        {
            return (await _context.Animals.ToListAsync())
                .Select(a => new AnimalViewModel { Id = a.Id, Type = a.GetType().Name });
        }

        public async Task<AnimalViewModel> GetAnimalById(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            return animal == null ? null : new AnimalViewModel { Id = animal.Id, Type = animal.GetType().Name };
        }

        public async Task UpdateAnimal(AnimalViewModel model)
        {
            var animal = await _context.Animals.FindAsync(model.Id);
            if (animal == null)
            {
                throw new ArgumentException("Invalid animal ID", nameof(model.Id));
            }

            // Here we assume that the Type property of the ViewModel corresponds to the type of the Animal.
            // If the type has changed, we need to create a new Animal of the correct type.
            if (animal.GetType().Name != model.Type)
            {
                _context.Animals.Remove(animal);

                switch (model.Type)
                {
                    case "Lion":
                        animal = new Lion();
                        break;
                    case "Elephant":
                        animal = new Elephant();
                        break;
                    default:
                        throw new ArgumentException("Invalid type", nameof(model.Type));
                }

                animal.Id = model.Id;
                _context.Animals.Add(animal);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAnimal(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal != null)
            {
                _context.Animals.Remove(animal);
                await _context.SaveChangesAsync();
            }
        }

    }
}
