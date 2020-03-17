using AnimalCreator.Data;
using AnimalCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalCreator.Services
{
    public class AnimalService
    {
        public bool CreateAnimal(AnimalCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new Animal()
                {
                    Name = model.Name
                };
                ctx.Animals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AnimalListItem> GetAllAnimals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Animals.Select(
                    a => new AnimalListItem()
                    {
                        Id = a.Id,
                        Name = a.Name
                    });
                return query.ToArray();
            }
        }

        public AnimalDetail GetAnimalById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Animals.Single(a => a.Id == id);
                return
                    new AnimalDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name
                    };
            }
        }

        public bool EditAnimal(AnimalEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Animals.Single(a => a.Id == model.Id);
                entity.Name = model.Name;
                return ctx.ChangeTracker.HasChanges();
            }
        }
        public bool DeleteAnimal(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Animals.Single(a => a.Id == id);
                ctx.Animals.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
