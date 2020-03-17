using AnimalCreator.Models;
using AnimalCreator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AnimalCreator.WebAPI.Controllers
{
    public class AnimalController : ApiController
    {
        public IHttpActionResult Post(AnimalCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new AnimalService();
           if(!service.CreateAnimal(model))
                return InternalServerError();
            return Ok(model);
        }

        public IHttpActionResult GetAll()
        {
            var service = new AnimalService();
            var listOfAnimals = service.GetAllAnimals();
            return Ok(listOfAnimals);
        }

        public IHttpActionResult GetById(int id)
        {
            var service = new AnimalService();
            var animalDetail = service.GetAnimalById(id);
            return Ok(animalDetail);
        }

        public IHttpActionResult Put(AnimalEdit model)
        {
            var service = new AnimalService();
            if (!service.EditAnimal(model))
                return InternalServerError();
            return Ok(model);
        }

        public IHttpActionResult Delete(int id)
        {
            var service = new AnimalService();
            if(!service.DeleteAnimal(id))
                return InternalServerError();
            return Ok();
        }
    }
}
