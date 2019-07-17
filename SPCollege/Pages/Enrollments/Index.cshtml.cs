using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SPCollege.Data;
using SPCollege.Models;

namespace SPCollege.Pages.Enrollments
{
    public class IndexModel : PageModel
    {
        private readonly SPCollege.Data.SchoolContext _context;

        public IndexModel(SPCollege.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Enrollment> Enrollment { get;set; }

        public async Task OnGetAsync()
        {
            Enrollment = await _context.Enrollments
                .Include(e => e.Course)
                .Include(e => e.Student).ToListAsync();
        }
    }
}
