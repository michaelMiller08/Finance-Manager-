using System;
using System.Collections;
using FinanceManager.Models;

namespace FinanceManager.ViewModels
{
    public interface IBillRepository
    {
        void AddBill(string name, string description, int price, BillOccurrence billoccurance, int id);

        void RemoveBill(int id);

        IEnumerable GetAllBills();
    }
}