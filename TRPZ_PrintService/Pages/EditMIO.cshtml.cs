using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TRPZ_PrintService.Data;

namespace TRPZ_PrintService.Pages
{
    public class EditMIO : PageModel
    {
        private TRPZ_PrintServiceContext _context;

        public SelectList Materials { get; set; }

        public SelectList PostProcessings { get; set; }

        public SelectList Printers { get; set; }
        [BindProperty] public Order order { get; set; }
        public ModelInOrder mio { get; set; }


        public class FormModel
        {
            public double Scale { get; set; }
            public bool HasSolubleSupports { get; set; }
            public int PostProcessingId { get; set; }
            public string Description { get; set; }

            public int InfillPercentage { get; set; }
            public int Layerheight { get; set; }
            public int NozzleDiameter { get; set; }

            public int PrinterId { get; set; }
            public int MaterialId { get; set; }
            public int Price { get; set; }
        }

        [BindProperty] public FormModel Fmodel { get; set; }

        public EditMIO(TRPZ_PrintServiceContext context)
        {
            _context = context;
        }


        public IActionResult OnGetEdit(int? orderId, int mioid)
        {
            Fmodel = new FormModel();
            mio = _context.ModelsInOrders
                .Include(inOrder => inOrder.Model)
                .Include(inOrder => inOrder.Order)
                .Include(inOrder => inOrder.Material)
                .Include(inOrder => inOrder.Printer)
                .Include(inOrder => inOrder.ModelSettings)
                .Include(inOrder => inOrder.PostProcessing)
                .First(inOrder => inOrder.ModelInOrderId == mioid);

            order = mio.Order;

            Fmodel.Description = mio.Model.Description;
            Fmodel.Layerheight = mio.ModelSettings.LayerHeight;
            Fmodel.Scale = mio.Scale;
            Fmodel.InfillPercentage = mio.ModelSettings.InfillPercentage;
            Fmodel.MaterialId = mio.Material.MaterialId;
            Fmodel.NozzleDiameter = mio.ModelSettings.NozzleDiameter;
            Fmodel.PrinterId = mio.Printer.PrinterId;
            Fmodel.HasSolubleSupports = mio.HasSolubleSupports;
            Fmodel.PostProcessingId = mio.PostProcessing.PostProcessingId;

            Fmodel.Price = mio.PriceTotal;

            Printers = new SelectList(_context.Printers.ToList(), nameof(Printer.PrinterId), nameof(Printer.Name));
            Materials = new SelectList(_context.Materials.ToList(), nameof(Material.MaterialId), nameof(Material.Name));
            PostProcessings = new SelectList(_context.PostProcessings.ToList(), nameof(PostProcessing.PostProcessingId),
                nameof(PostProcessing.Name));

            return Page();
        }

        public IActionResult OnPostEdit(int? orderId, int mioid)
        {
            mio = _context.ModelsInOrders
                .Include(inOrder => inOrder.Model)
                .Include(inOrder => inOrder.Order)
                .Include(inOrder => inOrder.Material)
                .Include(inOrder => inOrder.Printer)
                .Include(inOrder => inOrder.ModelSettings)
                .Include(inOrder => inOrder.PostProcessing)
                .First(inOrder => inOrder.ModelInOrderId == mioid);

            order = mio.Order;

            mio.Model.Description = Fmodel.Description;
            mio.ModelSettings.LayerHeight = Fmodel.Layerheight;
            mio.Scale = Fmodel.Scale;
            mio.ModelSettings.InfillPercentage = Fmodel.InfillPercentage;
            mio.Material = _context.Materials.Find(Fmodel.MaterialId);
            mio.ModelSettings.NozzleDiameter = Fmodel.NozzleDiameter;
            mio.Printer.PrinterId = Fmodel.PrinterId;
            mio.HasSolubleSupports = Fmodel.HasSolubleSupports;
            mio.PostProcessing.PostProcessingId = Fmodel.PostProcessingId;

            mio.PriceTotal = Fmodel.Price;

            // Printers = new SelectList(_context.Printers.ToList(), nameof(Printer.PrinterId), nameof(Printer.Name));
            // Materials = new SelectList(_context.Materials.ToList(), nameof(Material.MaterialId), nameof(Material.Name));
            // PostProcessings = new SelectList(_context.PostProcessings.ToList(), nameof(PostProcessing.PostProcessingId),
            //     nameof(PostProcessing.Name));

            _context.SaveChanges();


            return new RedirectToPageResult("/ModelInOrder", "", new {id = order.OrderId});
        }
    }
}