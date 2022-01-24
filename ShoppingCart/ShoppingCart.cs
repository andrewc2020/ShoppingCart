


    namespace ShoppingCart.ShoppingCart
    {
            using EventFeed;
        public class ShoppingCart
        {

            public int UserId { get; }
            private HashSet<ShoppingCartItem> items = new HashSet<ShoppingCartItem>();
            public IEnumerable<ShoppingCartItem> Items { get { return items; } }
            public ShoppingCart(int userid)
            {
                UserId = userid;

            }
            public void AddItems(IEnumerable<ShoppingCartItem> shoppingCartItems, IEventStore eventStore)
            {
                foreach (var item in shoppingCartItems)
                {
                    if (this.items.Add(item))
                    {
                        eventStore.Raise("ShoppingCartItemAdded", new { UserId, item });
                    }
                }
            }

            public void RemoveItems(int[] productCatalogIds, IEventStore eventStore)
            {
                items.RemoveWhere(i => productCatalogIds.Contains(i.ProductCatalogId));
            }
        }

        public class ShoppingCartItem
        {
            public int ProductCatalogId { get; }
            public string ProductName { get; }
            public string Description { get; }
            public Money Price { get; }

            public ShoppingCartItem(int productCatalogId, string productName, string description, Money price)
            {
                this.ProductCatalogId = productCatalogId;
                this.ProductName = productName;
                this.Description = description;
                this.Price = price;
            }

            public bool Equals(ShoppingCartItem item)
            {


                if (item == null)
                {
                    return false;
                }
                else if (GetType() != item.GetType())
                {
                    return false;
                }
                else
                {

                    return this.ProductCatalogId.Equals(item.ProductCatalogId);

                }



            }

            public override int GetHashCode()
            {
                return this.ProductCatalogId.GetHashCode();
            }
        }

        public class Money
        {
            public string Currency { get; }
            public decimal Amount { get; }

            public Money(string currency, decimal amount)
            {
                this.Currency = currency;
                this.Amount = amount;
            }
        }

    }
