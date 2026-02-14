using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManager.Database;
using TaskManager.Models;

namespace TaskManager.Pages
{
    public class CreateModel : PageModel
    {
        private readonly TaskManager.Database.AppDbContext _context;

        public CreateModel(TaskManager.Database.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserTask UserTask { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserTasks.Add(UserTask);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
