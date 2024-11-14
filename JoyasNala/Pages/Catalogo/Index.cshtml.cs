using JoyasNala.Data;
using JoyasNala.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JoyasNala.Pages.Catalogo
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Producto> Productos { get; set; }

        public async Task OnGetAsync()
        {
            Productos = await _context.Productos.ToListAsync();
        }
    }
}
