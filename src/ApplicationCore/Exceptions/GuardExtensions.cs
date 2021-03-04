using ApplicationCore.Entities.CartAggregate;
using Ardalis.GuardClauses;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Exceptions
{
    public static class CartGuards
    {
        public static void NullCart(this IGuardClause guardClause, int cartId, Cart cart)
        {
            if (cart == null)
                throw new CartNotFoundException(cartId);
        }

        public static void EmptyCartOnCheckout(this IGuardClause guardClause, IReadOnlyCollection<CartItem> cartItems)
        {
            if (!cartItems.Any())
                throw new EmptyCartOnCheckoutException();
        }
    }
}
