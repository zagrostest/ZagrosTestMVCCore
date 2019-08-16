using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZagrosTestProject;
using ZagrosTestProject.Entities;
using ZagrosTestProject.GenericRepository;

namespace ZagrosTestProject.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        
        private IRepository<Person> _personService;
        private IRepository<GenderType> _genderService;
        private IRepository<MaritalStatusType> _maritalStatusService;

        public PersonController(IRepository<Person> personService, IRepository<GenderType> genderService,
            IRepository<MaritalStatusType> maritalStatusService)
        {
            _personService = personService;
            _genderService = genderService;
            _maritalStatusService = maritalStatusService;
        }

        // GET: Person
        public async Task<IActionResult> Index()
        {
            ViewData["GenderId"] = _genderService.ListAllAsync();
            ViewData["MaritalStatusId"] = _maritalStatusService.ListAllAsync();
            return View(await _personService.ListAllAsync());
        }

        //// GET: Person/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ViewData["GenderId"] = _genderService.ListAllAsync();
            ViewData["MaritalStatusId"] = _maritalStatusService.ListAllAsync();
            var person = await _personService.GetByIdAsync(id);
            return View(person);
        }

        //// GET: Person/Create
        public async Task<IActionResult> Create()
        {
            var gen= (IEnumerable)await _genderService.ListAllAsync();
            var mar= (IEnumerable)await _maritalStatusService.ListAllAsync();
            ViewData["GenderId"] = new SelectList(gen, "Id", "GenderDescription");
            ViewData["MaritalStatusId"] = new SelectList(mar, "Id", "MaritalStatusDescription");
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,GenderId,Birthdate,MaritalStatusId")] Person person)
        {
            await _personService.AddAsync(person);
            return RedirectToAction(nameof(Index));
        }

        // GET: Person/Edit/5
        public async Task<IActionResult> Edit(int id)

        {
            var gen = (IEnumerable)await _genderService.ListAllAsync();
            var mar = (IEnumerable)await _maritalStatusService.ListAllAsync();
            ViewData["GenderId"] = new SelectList(gen, "Id", "GenderDescription");
            ViewData["MaritalStatusId"] = new SelectList(mar, "Id", "MaritalStatusDescription");
            var person = await _personService.GetByIdAsync(id);
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,GenderId,Birthdate,MaritalStatusId")] Person person)
        {
            await _personService.UpdateAsync(person);
            return RedirectToAction(nameof(Index));
        }

        // GET: Person/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var gen = (IEnumerable)await _genderService.ListAllAsync();
            var mar = (IEnumerable)await _maritalStatusService.ListAllAsync();
            ViewData["GenderId"] = new SelectList(gen, "Id", "GenderDescription");
            ViewData["MaritalStatusId"] = new SelectList(mar, "Id", "MaritalStatusDescription");

            var person = await _personService.GetByIdAsync(id);
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            await _personService.DeleteAsync(person);
            return RedirectToAction(nameof(Index));
        }
    }
    }
