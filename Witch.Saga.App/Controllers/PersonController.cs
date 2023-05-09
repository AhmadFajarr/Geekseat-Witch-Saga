using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Witch.Saga.App.Models;
using Witch.Saga.App.Models.ViewModel;
using Witch.Saga.App.Services;

namespace Witch.Saga.App.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonServices _personServices;

        public PersonController(PersonServices personServices)
        {
            _personServices = personServices;
        }

        public IActionResult Index()
        {
            var list = _personServices.GetList();

            double average = 0;
            if (list.Count > 0)
            {
                double averageCount = Convert.ToDouble(list.Count);
                double averageSum = Convert.ToDouble(list.Sum(x => x.AverageNumber));

                average = averageSum / averageCount;
            }
           
            ViewBag.AverageNumber = average;
            return View(list);
        }

        public IActionResult Create()
        {
            var resource = new PersonViewModel();
            return View(resource);
        }

        [HttpPost]
        public IActionResult Create(PersonViewModel person)
        {
            try
            {
                var objModel = MergeViewModelToModel(person);
                _personServices.Create(objModel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.GetBaseException().Message;
                return View(person);
            }
        }

        private Person MergeViewModelToModel(PersonViewModel person)
        {
            var data = new Person();
            data.AgeOfDeath = person.AgeOfDeath;
            data.YearOfDeath = person.YearOfDeath;

            HelperServices _helperServices = new HelperServices();
            int killedYear = (int)(person.YearOfDeath - person.AgeOfDeath);
            int averageNumber = _helperServices.CalculateAverageNumber(killedYear);

            data.AverageNumber = averageNumber;

            return data;
        }

       
    }
}
