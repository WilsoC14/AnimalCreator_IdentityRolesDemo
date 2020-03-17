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
            var service = new AnimalService();
            service.CreateAnimal(model);
            return Ok(model);
        }

        public IHttpActionResult GetAll()
        {
            var service = new AnimalService();
            var listOfAnimals = service.GetAllAnimals();
            return Ok(listOfAnimals);
        }

    }
}
