namespace ShoppingCart.ShoppingCart{
    using EventFeed;

    interface IShoppingCart{

        void AddItems(IEnumerable<ShoppingCartItem> shoppingCartItems, IEventStore eventStore);

    }
}