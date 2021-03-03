using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.OrderAggregate
{
    public class Order: BaseEntity
    {
        private Order()
        {
            // required by EF
        }

        public Order(string customerId, Address shipToAddress, List<OrderItem> items)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.Null(shipToAddress, nameof(shipToAddress));
            Guard.Against.Null(items, nameof(items));

            CustomerId = customerId;
            ShipToAddress = shipToAddress;
            _orderItems = items;
        }

        public string CustomerId { get; private set; }
        public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;
        public Address ShipToAddress { get; private set; }

        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public decimal Total()
        {
            var total = 0m;
            foreach (var item in _orderItems)
            {
                total += item.UnitPrice * item.Units;
            }
            return total;
        }   
    }
}
