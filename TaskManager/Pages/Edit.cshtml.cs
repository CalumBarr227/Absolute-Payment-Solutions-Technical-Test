using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManager.Database;
using TaskManager.Models;

namespace TaskManager.Pages
{
    public class EditModel : PageModel
    {
        private readonly TaskManager.Database.AppDbContext _context;

        public EditModel(TaskManager.Database.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserTask UserTask { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserTask = await _context.UserTasks.FirstOrDefaultAsync(m => m.Id == id);

            if (UserTask == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTaskExists(UserTask.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserTaskExists(int id)
        {
            return _context.UserTasks.Any(e => e.Id == id);
        }
    }
}
