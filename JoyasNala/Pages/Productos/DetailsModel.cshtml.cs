using JoyasNala.Data;
using JoyasNala.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JoyasNala.Pages.Productos
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Producto Producto { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);

            if (Producto == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
