using FinanceManager.ViewModels;
using NUnit.Framework;
using System.Linq;

namespace FinanceManager.Tests
{
    [TestFixture()]
    public class CreateBillTests
    {
        const string PresetBillName = "Test bill name";
        const string PresetBillDescription = "Test bill description";
        const float PresetBillCost = 99F;
        const string PresetBillOccurance = "Monthly";

        [Test()]
        public void AddNewBill()
        {
            IBillRepository _billRepository = new BillRepository();

            _billRepository.AddBill(PresetBillName, PresetBillDescription, PresetBillCost, PresetBillOccurance);

            var createdBillId = _billRepository.GetAllBills().FirstOrDefault(p => p.Name == PresetBillName).Id;

            Assert.IsTrue(_billRepository.CheckBillExists(createdBillId));
        }
    }
}
