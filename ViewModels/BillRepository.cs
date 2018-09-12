using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FinanceManager.Models;

namespace FinanceManager.ViewModels
{
    public class BillRepository : IBillRepository
    {
       readonly List<Bill> _bills = new List<Bill>();

        public void AddBill(string name, string description, float cost, string billOccurance)
        {
            var randomId = new Random().Next();

            var bill = new Bill
            {
                Name = name,
                Description = description,
                Cost = cost,
                Occurrence = billOccurance,
                Id = randomId
            };

            if (!_bills.Contains(bill) && bill != null)
            {
                _bills.Add(bill);
            }
        }

        public bool CheckBillExists(int id)
        {
            var requestedBill = _bills.First(p => p.Id == id);

            return _bills.Contains(requestedBill);
        }

        public IEnumerable<Bill> GetAllBills()
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