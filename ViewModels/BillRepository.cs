using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FinanceManager.Models;

namespace FinanceManager.ViewModels
{
    public class BillRepository : IBillRepository
    {
        List<Bill> _bills = new List<Bill>();

        public void AddBill(string name, string description, int price, BillOccurrence billOccurance, int id)
        {
            var random = new Random();
            var randomId = random.Next();

            var bill = new Bill
            {
                Name = name,
                Description = description,
                Price = price,
                Occurrence = billOccurance,
                Id = randomId
            };

            _bills.Add(bill);
        }

        public IEnumerable GetAllBills()
        {
            return _bills;
        }

        public void RemoveBill(int id)
        {
            var requestedBill = _bills.First(p => p.Id == id);

            _bills.Remove(requestedBill);
        }
    }
}