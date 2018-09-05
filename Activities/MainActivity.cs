using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace FinanceManager
{
    [Activity(Label = "Finance Manager", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);
        }
    }
}

