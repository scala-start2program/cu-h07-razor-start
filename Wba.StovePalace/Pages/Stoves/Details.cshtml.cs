using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Wba.StovePalace.Data;
using Wba.StovePalace.Models;

namespace Wba.StovePalace.Pages.Stoves
{
    public class DetailsModel : PageModel
    {
        private readonly Wba.StovePalace.Data.StoveContext _context;

        public DetailsModel(Wba.StovePalace.Data.StoveContext context)
        {
            _context = context;
        }

      public Stove Stove { get; set; }

        public  IActionResult OnGet(int? id)
        {
            if (id == null || _context.Stove == null)
            {
                return NotFound();
            }

            var stove =  _context.Stove
                .Include(b => b.Brand)
                .Include(f => f.Fuel).ToList()
                .FirstOrDefault(m => m.Id == id);
            if (stove == null)
            {
                return NotFound();
            }
            else 
            {
                Stove = stove;
            }
            return Page();
        }
    }
}
