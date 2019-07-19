using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SPCollege.Data;
using SPCollege.Models;

namespace SPCollege.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly SPCollege.Data.SchoolContext _context;

        public IndexModel(SPCollege.Data.SchoolContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            CurrentFilter = searchString;

            IQueryable<Student> studentIQ = from s in _context.Students
                                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                //if the search string is not empty we will list the results as such
                studentIQ = studentIQ.Where(s => s.LastName.Contains(searchString)
                || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                //switching the sort order basaed on name and date
                case "name_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    studentIQ = studentIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    studentIQ = studentIQ.OrderBy(s => s.LastName);
                    break;
            }
            Student = await studentIQ.AsNoTracking().ToListAsync();
        }
    }
}
