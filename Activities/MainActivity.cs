using Android.App;
using Android.Widget;
using Android.OS;

namespace FinanceManager
{
    [Activity(Label = "FinanceManager", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);
        }
    }
}

