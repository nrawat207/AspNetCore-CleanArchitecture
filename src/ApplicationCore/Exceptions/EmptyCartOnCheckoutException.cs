using System;

namespace ApplicationCore.Exceptions
{
    public class EmptyCartOnCheckoutException:Exception
    {
        public EmptyCartOnCheckoutException()
           : base($"Cart cannot have 0 items on checkout")
        {
        }

        protected EmptyCartOnCheckoutException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public EmptyCartOnCheckoutException(string message) : base(message)
        {
        }

        public EmptyCartOnCheckoutException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
