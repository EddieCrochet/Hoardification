using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SPCollege.Data;
using SPCollege.Models;

namespace SPCollege.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly SPCollege.Data.SchoolContext _context;

        public IndexModel(SPCollege.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; }

        public async Task OnGetAsync()
        {
            Course = await _context.Courses.ToListAsync();
        }
    }
}
