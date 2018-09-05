using Android.App;
using Android.OS;
using Android.Views;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content;
using FinanceManager.Activities;

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
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.menu_add_new_bill)
            {
                //var intent = new Intent(this, typeof(CreateBillActivity));
                //StartActivity(intent);
                StartActivity(new Intent(this, typeof(CreateBillActivity)));
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

