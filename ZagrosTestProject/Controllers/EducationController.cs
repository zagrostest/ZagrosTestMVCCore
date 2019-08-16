//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using ZagrosTestProject;
//using ZagrosTestProject.Entities;

//namespace ZagrosTestProject.Controllers
//{
//    [Authorize]
//    public class EducationController : Controller
//    {
//        private readonly ASPCoreDBContext _context;

//        public EducationController(ASPCoreDBContext context)
//        {
//            _context = context;
//        }

//        // GET: Education
//        public async Task<IActionResult> Index()
//        {
//            var aSPCoreDBContext = _context.Educations.Include(e => e.Personnel).Include(e => e.EducationDegreeType);
//            return View(await aSPCoreDBContext.ToListAsync());
//        }

//        // GET: Education/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var education = await _context.Educations
//                .Include(e => e.Personnel).Include(e=> e.EducationDegreeType)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (education == null)
//            {
//                return NotFound();
//            }

//            return View(education);
//        }

//        // GET: Education/Create
//        public IActionResult Create()
//        {
//            ViewData["EducationDegreeTypeId"] = new SelectList(_context.EducationDegreeTypes, "Id", "EducationDegreeDescription");
//            ViewData["PersonnelId"] = new SelectList(_context.Personnels, "Id", "Id");

//            return View();
//        }

//        // POST: Education/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,PersonnelId,EducationDegreeTypeId,FromDate,ToDate")] Education education)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(education);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["PersonnelId"] = new SelectList(_context.Personnels, "Id", "Id", education.PersonnelId);
//            ViewData["EducationDegreeTypeId"] = new SelectList(_context.EducationDegreeTypes, "Id", "EducationDegreeDescription", education.EducationDegreeTypeId);

//            return View(education);
//        }

//        // GET: Education/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var education = await _context.Educations.FindAsync(id);
//            if (education == null)
//            {
//                return NotFound();
//            }
//            ViewData["PersonnelId"] = new SelectList(_context.Personnels, "Id", "Id", education.PersonnelId);
//            ViewData["EducationDegreeTypeId"] = new SelectList(_context.EducationDegreeTypes, "Id", "EducationDegreeDescription", education.EducationDegreeTypeId);

//            return View(education);
//        }

//        // POST: Education/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonnelId,EducationDegreeTypeId,FromDate,ToDate")] Education education)
//        {
//            if (id != education.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(education);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!EducationExists(education.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["PersonnelId"] = new SelectList(_context.Personnels, "Id", "Id", education.PersonnelId);
//            return View(education);
//        }

//        // GET: Education/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var education = await _context.Educations
//                .Include(e => e.Personnel).Include(e=>e.EducationDegreeType)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (education == null)
//            {
//                return NotFound();
//            }

//            return View(education);
//        }

//        // POST: Education/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var education = await _context.Educations.FindAsync(id);
//            _context.Educations.Remove(education);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool EducationExists(int id)
//        {
//            return _context.Educations.Any(e => e.Id == id);
//        }
//    }
//}
//===========================================================================

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
    public class EducationController : Controller
    {

        private IRepository<Education> _educationService;
        private IRepository<Personnel> _personnelService;
        private IRepository<EducationDegreeType> _educationDegreeService;

        public EducationController(IRepository<Education> educationService, IRepository<Personnel> personnelService,
            IRepository<EducationDegreeType> educationDegreeService)
        {
            _educationService = educationService;
            _personnelService = personnelService;
            _educationDegreeService = educationDegreeService;
        }

        // GET: Education
        public async Task<IActionResult> Index()
        {
            ViewData["PersonnelId"] = _personnelService.ListAllAsync();
            ViewData["EducationDegreeTypeId"] = _educationDegreeService.ListAllAsync();
            return View(await _educationService.ListAllAsync());
        }

        //// GET: Education/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ViewData["PersonnelId"] = _personnelService.ListAllAsync();
            ViewData["EducationDegreeTypeId"] = _educationDegreeService.ListAllAsync();
            var education = await _educationService.GetByIdAsync(id);
            return View(education);
        }

        //// GET: Education/Create
        public async Task<IActionResult> Create()
        {
            var prs = (IEnumerable)await _personnelService.ListAllAsync();
            var mar = (IEnumerable)await _educationDegreeService.ListAllAsync();
            ViewData["PersonnelId"] = new SelectList(prs, "Id", "Id");
            ViewData["EducationDegreeTypeId"] = new SelectList(mar, "Id", "EducationDegreeDescription");
            return View();
        }

        // POST: Education/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonnelId,FromDate,ToDate,EducationDegreeTypeId")] Education education)
        {
            await _educationService.AddAsync(education);
            return RedirectToAction(nameof(Index));
        }

        // GET: Education/Edit/5
        public async Task<IActionResult> Edit(int id)

        {
            var prs = (IEnumerable)await _personnelService.ListAllAsync();
            var mar = (IEnumerable)await _educationDegreeService.ListAllAsync();
            ViewData["PersonnelId"] = new SelectList(prs, "Id", "Id");
            ViewData["EducationDegreeTypeId"] = new SelectList(mar, "Id", "EducationDegreeDescription");
            var education = await _educationService.GetByIdAsync(id);
            return View(education);
        }

        // POST: Education/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonnelId,FromDate,ToDate,EducationDegreeTypeId")] Education education)
        {
            await _educationService.UpdateAsync(education);
            return RedirectToAction(nameof(Index));
        }

        // GET: Education/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var prs = (IEnumerable)await _personnelService.ListAllAsync();
            var mar = (IEnumerable)await _educationDegreeService.ListAllAsync();
            ViewData["PersonnelId"] = new SelectList(prs, "Id", "Id");
            ViewData["EducationDegreeTypeId"] = new SelectList(mar, "Id", "EducationDegreeDescription");

            var education = await _educationService.GetByIdAsync(id);
            return View(education);
        }

        // POST: Education/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education = await _educationService.GetByIdAsync(id);
            await _educationService.DeleteAsync(education);
            return RedirectToAction(nameof(Index));
        }
    }
}

