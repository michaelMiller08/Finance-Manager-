using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Autofac;
using FinanceManager.ViewModels;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FinanceManager.Activities
{
    [Activity(Label = "CreateBillActivity")]
    public class CreateBillActivity : BaseActivity
    {
        string _billName;
        string _billDescription;
        string _billCost;
        string _billOccurence;
        string[] _costOccurences;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_create_bill);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarActivityCreateBill);
            SetupToolbar(toolbar: toolbar, title: Resource.String.create_bill_title, homeEnabled: true, displayAsHome: true);

            var occurenceSpinner = FindViewById<Spinner>(Resource.Id.occurence_spinner);
            occurenceSpinner.ItemSelected += OccurenceSpinner_ItemSelected;

            _costOccurences = new string[]{ "Daily", "Weekly", "Bi-Monthly", "Monthly", "Quarterly", "Annually" };
            
            var spinnerAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, _costOccurences);
            spinnerAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            occurenceSpinner.Adapter = spinnerAdapter;

            FindViewById<Button>(Resource.Id.add_bill_btn).Click += CreateBillBtn_Click;
        }

        public override bool OnSupportNavigateUp()
        {
            //OnBackPressed();
            StartActivity(new Intent(this, typeof(MainActivity)));
            return true;
        }

        void OccurenceSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var Occurence = _costOccurences[e.Position];

            _billOccurence = Occurence;
        }

        void CreateBillBtn_Click(object sender, System.EventArgs e)
        {
            _billName = FindViewById<EditText>(Resource.Id.name_input).Text;
            _billDescription = FindViewById<EditText>(Resource.Id.description_input).Text;
            _billCost = FindViewById<EditText>(Resource.Id.cost_input).Text;

            var basket = App.Container.Resolve<IBillRepository>();
            basket.AddBill(_billName, _billDescription, _billCost, _billOccurence);
        }
    }
}
