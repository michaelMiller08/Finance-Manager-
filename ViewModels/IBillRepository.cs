using System.Collections.Generic;
using FinanceManager.Models;

namespace FinanceManager.ViewModels
{
    public interface IBillRepository
    {
        void AddBill(string name, string description, float cost, string billoccurance);

        void RemoveBill(int id);

        bool CheckBillExists(int id);

        IEnumerable<Bill> GetAllBills();
    }
}