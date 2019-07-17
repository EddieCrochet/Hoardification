using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SPCollege.Data;
using SPCollege.Models;

namespace SPCollege.Pages.Enrollments
{
    public class CreateModel : PageModel
    {
        private readonly SPCollege.Data.SchoolContext _context;

        public CreateModel(SPCollege.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
        ViewData["StudentID"] = new SelectList(_context.Students, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Enrollments.Add(Enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}