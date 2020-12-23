using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TRPZ_PrintService.Data;

namespace TRPZ_PrintService.Pages
{
    public class ModelInOrderPage : PageModel
    {
        private TRPZ_PrintServiceContext _context;
        private IWebHostEnvironment _environment;

        [BindProperty] public Order order { get; set; }

        public class FormModel
        {
            public double Scale { get; set; }
            public bool HasSolubleSupports { get; set; }
            public int PostProcessingId { get; set; }
            public String Description { get; set; }

            public int InfillPercentage { get; set; }
            public int Layerheight { get; set; }
            public int NozzleDiameter { get; set; }

            public int PrinterId { get; set; }
            public int MaterialId { get; set; }
        }

        [BindProperty] public FormModel Fmodel { get; set; }
        public SelectList Printers { get; set; }

        public SelectList Materials { get; set; }
        public SelectList PostProcessings { get; set; }
        [Required] [BindProperty] public IFormFile Upload { get; set; }


        public ModelInOrderPage(TRPZ_PrintServiceContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            order = _context.Orders.Include(order1 => order1.Models)
                .ThenInclude(inOrder => inOrder.Model)
                .Include(order1 => order1.Models)
                .ThenInclude(inOrder => inOrder.ModelSettings)
                .First(order1 => order1.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            Printers = new SelectList(_context.Printers.ToList(), nameof(Printer.PrinterId), nameof(Printer.Name));
            Materials = new SelectList(_context.Materials.ToList(), nameof(Material.MaterialId), nameof(Material.Name));
            PostProcessings = new SelectList(_context.PostProcessings.ToList(), nameof(PostProcessing.PostProcessingId), nameof(PostProcessing.Name));

            Fmodel = new FormModel();
            Fmodel.Scale = 100;

            return Page();
        }

        public async Task<IActionResult> OnPostRemove(int id, int mioid)
        {
            var modelInOrder = await _context.ModelsInOrders.FindAsync(mioid);
            _context.ModelsInOrders.Remove(modelInOrder);
            _context.SaveChanges();
            
            return new RedirectToPageResult("/ModelInOrder", "", new{id});
        }
        public async Task<IActionResult> OnPostCreate(int id)
        {
            order = _context.Orders.Find(id);
            var uploadFileName = Upload.FileName + "_" + DateTime.Now.Ticks;
            var file = Path.Combine(_environment.ContentRootPath, "uploads",
                uploadFileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }

            var ms = new ModelSettings()
            {
                InfillPercentage = Fmodel.InfillPercentage,
                LayerHeight = Fmodel.Layerheight,
                NozzleDiameter = Fmodel.NozzleDiameter,
            };

            var m = new Model3D()
            {
                Description = Fmodel.Description,
                FilePath = uploadFileName,
            };

            var printer = await _context.Printers.FindAsync(Fmodel.PrinterId);
            var material = await _context.Materials.FindAsync(Fmodel.MaterialId);
            var pp = await _context.PostProcessings.FindAsync(Fmodel.PostProcessingId);

            var mio = new ModelInOrder()
            {
                Manager = null,
                Material = material,
                Model = m,
                Order = order,
                Printer = printer,
                Scale = Fmodel.Scale,
                ModelSettings = ms,
                PostProcessing = pp,
                HasSolubleSupports = Fmodel.HasSolubleSupports,
            };

            order.Models.Add(mio);
            await _context.SaveChangesAsync();

            return new RedirectToPageResult("/ModelInOrder", "", new{id});
        }
    }
}