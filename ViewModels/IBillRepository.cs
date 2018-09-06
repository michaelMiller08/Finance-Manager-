using System.Collections.Generic;
using FinanceManager.Models;

namespace FinanceManager.ViewModels
{
    public interface IBillRepository
    {
        void AddBill(string name, string description, string cost, string billoccurance);

        void RemoveBill(int id);

        IEnumerable<Bill> GetAllBills();
    }
}