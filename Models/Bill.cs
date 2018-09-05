using System;
namespace FinanceManager.Models
{
	public class Bill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Enum Occurrence { get; set; }
        public int Id { get; set; }
    }
}