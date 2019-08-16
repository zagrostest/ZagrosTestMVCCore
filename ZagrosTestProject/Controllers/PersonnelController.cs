
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
    public class PersonnelController : Controller
    {

        private IRepository<Personnel> _personnelService;
        private IRepository<GenderType> _genderService;
        private IRepository<MaritalStatusType> _maritalStatusService;
        private IRepository<PositionType> _positionService;

        

        public PersonnelController(IRepository<Personnel> personnelService, IRepository<GenderType> genderService,
            IRepository<MaritalStatusType> maritalStatusService, IRepository<PositionType> positionService)
        {
            _personnelService = personnelService;
            _genderService = genderService;
            _maritalStatusService = maritalStatusService;
            _positionService = positionService;
        }

        // GET: Person
        public async Task<IActionResult> Index()
        {
            ViewData["GenderId"] = _genderService.ListAllAsync();
            ViewData["PositionId"] = _positionService.ListAllAsync();
            ViewData["MaritalStatusId"] = _maritalStatusService.ListAllAsync();
            return View(await _personnelService.ListAllAsync());
        }

        //// GET: Person/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ViewData["GenderId"] = _genderService.ListAllAsync();
            ViewData["PositionId"] = _positionService.ListAllAsync();
            ViewData["MaritalStatusId"] = _maritalStatusService.ListAllAsync();
            var personnel = await _personnelService.GetByIdAsync(id);
            return View(personnel);
        }

        //// GET: Person/Create
        public async Task<IActionResult> Create()
        {
            var gen = (IEnumerable)await _genderService.ListAllAsync();
            var pos = (IEnumerable)await _positionService.ListAllAsync();
            var mar = (IEnumerable)await _maritalStatusService.ListAllAsync();
            ViewData["GenderId"] = new SelectList(gen, "Id", "GenderDescription");
            ViewData["PositionId"] = new SelectList(pos, "Id", "PositionDescription"); 
            ViewData["MaritalStatusId"] = new SelectList(mar, "Id", "MaritalStatusDescription");
            return View();
        }

        // POST: Personnel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,GenderId,Birthdate,PositionId,MaritalStatusId")] Personnel personnel)
        {
            await _personnelService.AddAsync(personnel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Personnel/Edit/5
        public async Task<IActionResult> Edit(int id)

        {
            var gen = (IEnumerable)await _genderService.ListAllAsync();
            var pos = (IEnumerable)await _positionService.ListAllAsync();
            var mar = (IEnumerable)await _maritalStatusService.ListAllAsync();
            ViewData["GenderId"] = new SelectList(gen, "Id", "GenderDescription");
            ViewData["PositionId"] = new SelectList(pos, "Id", "PositionDescription");
            ViewData["MaritalStatusId"] = new SelectList(mar, "Id", "MaritalStatusDescription");
            var personnel = await _personnelService.GetByIdAsync(id);
            return View(personnel);
        }

        // POST: Personnel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,GenderId,Birthdate,PositionId,MaritalStatusId")] Personnel personnel)
        {
            await _personnelService.UpdateAsync(personnel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Personnel/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var gen = (IEnumerable)await _genderService.ListAllAsync();
            var pos = (IEnumerable)await _positionService.ListAllAsync();
            var mar = (IEnumerable)await _maritalStatusService.ListAllAsync();
            ViewData["GenderId"] = new SelectList(gen, "Id", "GenderDescription");
            ViewData["PositionId"] = new SelectList(pos, "Id", "PositionDescription");
            ViewData["MaritalStatusId"] = new SelectList(mar, "Id", "MaritalStatusDescription");

            var personnel = await _personnelService.GetByIdAsync(id);
            return View(personnel);
        }

        // POST: Personnel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personnel = await _personnelService.GetByIdAsync(id);
            await _personnelService.DeleteAsync(personnel);
            return RedirectToAction(nameof(Index));
        }
    }
}

