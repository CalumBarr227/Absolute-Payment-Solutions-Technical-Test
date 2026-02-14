using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManager.Database;
using TaskManager.Models;

namespace TaskManager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TaskManager.Database.AppDbContext _context;

        public IndexModel(TaskManager.Database.AppDbContext context)
        {
            _context = context;
        }

        public IList<UserTask> UserTask { get;set; }

        public async Task OnGetAsync()
        {
            UserTask = await _context.UserTasks.ToListAsync();
        }
    }
}
