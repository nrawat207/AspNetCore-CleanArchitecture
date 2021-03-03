using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.CustomerAggregate
{
    public class Customer: BaseEntity
    {
        public string CustGuid { get; private set; }

        private List<PaymentDetail> _paymentDetails = new List<PaymentDetail>();

        public IEnumerable<PaymentDetail> PaymentDetails => _paymentDetails.AsReadOnly();

        private Customer()
        {
            // required by EF
        }

        public Customer(string custGuid) : this()
        {
            Guard.Against.NullOrEmpty(custGuid, nameof(custGuid));
            CustGuid = custGuid;
        }

    }
}
