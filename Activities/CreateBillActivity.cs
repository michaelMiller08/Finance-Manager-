using Android.App;
using Android.OS;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FinanceManager.Activities
{
    [Activity(Label = "CreateBillActivity")]
    public class CreateBillActivity : BaseActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_create_bill);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarActivityCreateBill);
            SetupToolbar(toolbar: toolbar, title: Resource.String.create_bill_title, homeEnabled: true, displayAsHome: true);
        }

        public override bool OnSupportNavigateUp()
        {
            OnBackPressed();
            return true;
        }
    }
}
