using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Autofac;
using FinanceManager.Activities;
using FinanceManager.ViewModels;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FinanceManager
{
    [Activity(Label = "Finance Manager", MainLauncher = true)]
    public class MainActivity : BaseActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarActivityMain);
            SetupToolbar(toolbar: toolbar, title: Resource.String.app_name);

            var billsPlaceHolder = FindViewById<TextView>(Resource.Id.bills_placeholder);

            var billRepository = App.Container.Resolve<IBillRepository>();
            foreach (var bill in billRepository.GetAllBills())
            {
                billsPlaceHolder.Text += string.Format($" Name: {bill.Name} \n Description: {bill.Description} \n Cost: {bill.Cost} \n Frequency: {bill.Occurrence} \n \n");
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.menu_add_new_bill)
            {
                StartActivity(new Intent(this, typeof(CreateBillActivity)));
                OverridePendingTransition(Resource.Animation.abc_slide_in_top, Resource.Animation.abc_slide_out_bottom);
            }
            else
            {
                DisplayAlert(string.Format($"Sorry, the {item} feature is still being worked on!"));
            }
            return base.OnOptionsItemSelected(item);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_items, menu);
            return base.OnCreateOptionsMenu(menu);
        }
    }
}

