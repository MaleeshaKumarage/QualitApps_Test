using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QualitApps_Test.Models.Models;
using QualitApps_Test.Services.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QualitApps_Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceService;
        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceService = invoiceRepository;
        }
        [HttpGet("GetAllInvoices")]
        
        public ActionResult<ICollection<Invoice>> GetBookings()
        {
            var invoices = _invoiceService.GetAllInvoices();
            return Ok(invoices);
        }

        [HttpGet("GetInvoice/{id}")]
        public IActionResult GetInvoice(Guid invoiceId)
        {
            var invoice = _invoiceService.GetInvoiceById(invoiceId);

            if (invoice is null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }

        [HttpPost("CreateInvoice")]
        [Authorize(Policy = "AdminOnly")]
        public ActionResult<Invoice> CreateBooking(Invoice invoice)
        {
            var existing = _invoiceService.GetInvoiceById(invoice.Id);
            if (existing != null)
            {
                return new JsonResult(new
                {
                    status = "error",
                    message = $"Duplicate entry"
                })
                {
                    StatusCode = 500
                };
            }
            var newInvoice = _invoiceService.CreateInvoice(invoice);

            return CreatedAtRoute("GetInvoice", new { id = newInvoice.Id }, newInvoice);
        }

        [HttpPut("UpdatInvoice/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public ActionResult<Invoice> UpdateInvoice(Invoice invoice)
        {
            var updatedInvoice = _invoiceService.UpdateInvoice(invoice);

            return CreatedAtAction("GetInvoice", new { id = updatedInvoice.Id }, updatedInvoice);
        }

        [HttpPut("VoidInvoice/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public ActionResult<JsonResult> VoidInvoice(Guid invoiceId)
        {
            var invoice = _invoiceService.GetInvoiceById(invoiceId);
            invoice.isVoid = true;
            var updatedInvoice = _invoiceService.UpdateInvoice(invoice);

            if (updatedInvoice.isVoid)
            {
                return new JsonResult(new
                {
                    status = "success",
                    message = $"Invoice with ID {updatedInvoice.Id} has been Voided."
                })
                {
                    StatusCode = 200
                };
            }
            else
            {
                return new JsonResult(new
                {
                    status = "error",
                    message = $"Failed to void invoice with ID {invoice.Id}."
                })
                {
                    StatusCode = 500
                };
            };
        }


    }
}
