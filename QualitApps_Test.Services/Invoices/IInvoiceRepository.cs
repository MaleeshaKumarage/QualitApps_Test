using QualitApps_Test.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualitApps_Test.Services.Invoices
{
    public interface IInvoiceRepository
    {
        public List<Invoice> GetAllInvoices();
        public Invoice GetInvoiceById(Guid invoiceId);
        public Invoice CreateInvoice(Invoice invoice);
        public Invoice UpdateInvoice(Invoice invoice);
        public int RemoveInvoice(Guid invoiceId);
    }
}
