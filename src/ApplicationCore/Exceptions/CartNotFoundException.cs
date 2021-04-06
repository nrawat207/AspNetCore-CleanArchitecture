using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Exceptions
{
    public class CartNotFoundException: Exception
    {
        public CartNotFoundException(long cartId) : base($"No cart found with id {cartId}")
        {
        }

        protected CartNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public CartNotFoundException(string message) : base(message)
        {
        }

        public CartNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
