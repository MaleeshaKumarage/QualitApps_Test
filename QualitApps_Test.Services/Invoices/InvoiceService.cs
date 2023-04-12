using QualitApps_Test.DataAccess;
using QualitApps_Test.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualitApps_Test.Services.Invoices
{
    public class InvoiceService : IInvoiceRepository
    {
        private readonly AppDbContext _context;
        public InvoiceService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public Invoice CreateInvoice(Invoice invoice)
        {
            var createdinvoice = _context.Invoices.Add(invoice);
            _context.SaveChanges();
            return createdinvoice.Entity;
        }

        public List<Invoice> GetAllInvoices()
        {
            return _context.Invoices.ToList();
        }

        public Invoice GetInvoiceById(Guid invoiceId)
        {
            var invoice = _context.Invoices.Find(invoiceId);
            return invoice;
        }

        public int RemoveInvoice(Guid invoiceId)
        {
            var invoice = _context.Invoices.Find(invoiceId);

            if (invoice == null)
            {
                return 0;
            }
            _context.Invoices.Remove(invoice);
            return _context.SaveChanges();
        }

        public Invoice UpdateInvoice(Invoice invoice)
        {
            var inv = _context.Invoices.Find(invoice.Id);
            var updatedInvoice = _context.Invoices.Update(inv);
            _context.SaveChanges();
            return updatedInvoice.Entity;
        }
    }
}
