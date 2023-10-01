using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Otel.BL.Abstract;
using Otel.Entitiy.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Otel.Mvc.Web.Controllers
{
    public class BillController : Controller
    {
      

        private readonly IBillManager manager;
        private readonly IValidator<Bill> validator;

        public BillController(IBillManager manager, IValidator<Bill> validator)
        {
            this.manager = manager;
            this.validator = validator;
        }
        public async Task<IActionResult>Index()
        {
            var fatura= await manager.GetAllAsync();
            return View(fatura);
        }
        public async Task<IActionResult> Create()
        {
            Bill birim = new();
            return View(birim);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Bill birim)
        {
            //ValidationResult result = await validator.ValidateAsync(Biz);
            //if (!ModelState.IsValid)
            //{
            //    return View(birim);
            //}
            await manager.InsertAsync(birim);
            return RedirectToAction(nameof(Index));
        }
    }
}
