using System;
namespace DapperExcercise
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CatogoryID { get; set; }
        public int OnSale { get; set; } 
        public string StockLevel { get; set; }

    }
}
