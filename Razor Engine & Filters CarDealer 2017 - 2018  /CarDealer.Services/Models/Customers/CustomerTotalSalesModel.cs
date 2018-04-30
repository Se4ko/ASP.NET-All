namespace CarDealer.Services.Models.Customers
{
    using Sales;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerTotalSalesModel
    {
        public string Name { get; set; }

        public bool IsYoungDriver { get; set; }

        public IEnumerable<SaleModel> BoughtCars { get; set; }

        public decimal TotalSpentMoney
        {
            get
            {
                return this.BoughtCars  // 1 - za da stane 0,10 primerno shtoto 10%  a drugoto e 0,05 prosto taka
                    .Sum(c => c.Price * (1 - (decimal)c.Discount - (this.IsYoungDriver ? 0.05m : 0m)));
            }
        }
    }
}