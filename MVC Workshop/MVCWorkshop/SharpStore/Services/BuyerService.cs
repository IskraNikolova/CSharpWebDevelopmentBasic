namespace SharpStore.Services
{
    using System;
    using BindingModels;
    using Data;
    using Enums;
    using Models;

    public class BuyerService : Service
    {
        public BuyerService(SharpStoreContext context)
            : base(context)
        {
        }

        public void AddPurchase(BuyerBindingModel model)
        {
            var purchase = new Purchase();
            purchase.BuyerName = model.BuyerName;
            purchase.BuyerAddress = model.BuyerAddress;
            purchase.BuyerPhone = model.BuyerPhone;
            purchase.DeliveryType = (DeliveryType)Enum.Parse(typeof(DeliveryType), model.DeliveryType);

            this.context.Purchases.Add(purchase);
            this.context.SaveChanges();
        }
    }
}
