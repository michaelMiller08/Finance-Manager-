using System;
namespace FinanceManager.Models
{
	public class Bill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cost { get; set; }
        public string Occurrence { get; set; }
        public int Id { get; set; }
    }
}