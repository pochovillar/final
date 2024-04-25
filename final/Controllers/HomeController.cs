using final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace final.Controllers
{
    public class HomeController : Controller
    {
        private IEntertainerRepository _repo;


        public HomeController(IEntertainerRepository temp) //setting up repository pattern
        {
            _repo = temp;
        }

        public IActionResult Index() //home apge view
        {
            return View();
        }
        [HttpGet]
        public IActionResult form() //form to edit or post a record
        {


            return View("form", new Entertainer());
        }


        [HttpPost]
        public IActionResult form(Entertainer response) //posting a record
        {
            if (ModelState.IsValid)
            {
                _repo.AddEntertainer(response); // Add a record to the database


                return View("Confirmation", response); //returning a confirmation page 
            }
            else
            {

                return View(response);
            }
        }

        public IActionResult display() //action that displays all of the entertainers
        {
            var entertainers = _repo.Entertainers.ToList();
            return View(entertainers);

        }

        [HttpGet]
        public IActionResult Edit(int EntertainerId) //get the specific entertainer record that we need to edit
        {

            var recordToEdit = _repo.Entertainers
                .Single(x => x.EntertainerId == EntertainerId);

            return View("form", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Entertainer updatedInfo) //posting updated information about an entertainer 
        {
            _repo.UpdateEntertainer(updatedInfo);


            return RedirectToAction("display");
        }
        public IActionResult Details(int EntertainerId) //displaying all the details of a specific record
        {

            var recordToView = _repo.Entertainers
                .Single(x => x.EntertainerId == EntertainerId);

            return View("Details", recordToView);
        }
        [HttpGet]
        public IActionResult Delete(int EntertainerId) // grabbing record to delete by the ID in the URL
        {
            var recordToDelete = _repo.Entertainers
                .Single(x => x.EntertainerId == EntertainerId);

            return View(recordToDelete);

        }
        [HttpPost]
        public IActionResult Delete(Entertainer entertainer) //actually deleting the record 
        {
            _repo.DeleteEntertainer(entertainer);

            return RedirectToAction("display");
        }
    }
}
