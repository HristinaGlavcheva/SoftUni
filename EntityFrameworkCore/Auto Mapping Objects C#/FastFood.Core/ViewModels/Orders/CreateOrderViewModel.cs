namespace FastFood.Core.ViewModels.Orders
{
    using FastFood.Core.ViewModels.Items;
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public List<CreateOrderItemViewModel> Items { get; set; }

        public List<CreateOrderEmployeeViewModel> Employees { get; set; }
    }
}
