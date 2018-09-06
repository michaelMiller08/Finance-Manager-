using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Widget;

namespace FinanceManager.Activities
{
    public class BaseActivity : AppCompatActivity
    {
        public void SetupToolbar(Toolbar toolbar,int title, bool homeEnabled = false, bool displayAsHome = false)
        {
                SetSupportActionBar(toolbar);
                SupportActionBar?.SetTitle(title);
                SupportActionBar?.SetHomeButtonEnabled(homeEnabled);
                SupportActionBar?.SetDisplayHomeAsUpEnabled(displayAsHome);
        }

        public void DisplayAlert(string alertMessage, string alertTitle = "Alert")
        {
            using (var alertDialog = new AlertDialog.Builder(this))
            {
                alertDialog.SetTitle(alertTitle);
                alertDialog.SetMessage(alertMessage);
                alertDialog.SetNeutralButton("OK", delegate { });
                alertDialog.Show();
            }
        }

        public void DisplayToast(string toastMessage)
        {
            Toast.MakeText(this,toastMessage,ToastLength.Short).Show();
        }
    }
}
