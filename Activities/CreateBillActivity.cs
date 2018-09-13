using Android.App;
using Android.Content;
using Android.Graphics;
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
        string _billOccurence;
        string[] _costOccurences;

        EditText _billNameField, _billDescriptionField, _billCostField;
        Spinner _occurenceSpinner;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_create_bill);

            InitilizeFields();

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarActivityCreateBill);
            SetupToolbar(toolbar: toolbar, title: Resource.String.create_bill_title, homeEnabled: true, displayAsHome: true);

            _occurenceSpinner.ItemSelected += OccurenceSpinner_ItemSelected;
            
            var spinnerAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, _costOccurences);
            spinnerAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _occurenceSpinner.Adapter = spinnerAdapter;

            FindViewById<Button>(Resource.Id.add_bill_btn).Click += CreateBillBtn_Click;
        }

        public override bool OnSupportNavigateUp()
        {
            OnBackPressed();
            return true;
        }

        public override void OnBackPressed()
        {
            StartActivity(new Intent(this, typeof(MainActivity)));
            OverridePendingTransition(Resource.Animation.abc_slide_in_bottom, Resource.Animation.abc_slide_out_bottom);
        }

        protected override void OnStop()
        {
            FindViewById<Button>(Resource.Id.add_bill_btn).Click -= CreateBillBtn_Click;
            base.OnStop();
        }

        void OccurenceSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var Occurence = _costOccurences[e.Position];

            _billOccurence = Occurence;
        }

        void CreateBillBtn_Click(object sender, System.EventArgs e)
        {
            if (InputFieldsValidationFailureStatus() == false)
            {
                var billName = _billNameField?.Text;
                var billRepository = App.Container.Resolve<IBillRepository>();
                billRepository.AddBill(_billNameField.Text, _billDescriptionField.Text, float.Parse(_billCostField.Text), _billOccurence);

                _billNameField.Text = string.Empty;
                _billDescriptionField.Text = string.Empty;
                _billCostField.Text = string.Empty;

                DisplayToast(string.Format($"{billName} has been added!"));
            }
            else
            {
                DisplayAlert("Fields cannot be empty!", "Error");
            }
        }

        void InitilizeFields()
        {
            _costOccurences = new string[] { "Daily", "Weekly", "Bi-Monthly", "Monthly", "Quarterly", "Annually" };

            _billNameField = FindViewById<EditText>(Resource.Id.name_input);
            _billDescriptionField = FindViewById<EditText>(Resource.Id.description_input);
            _billCostField = FindViewById<EditText>(Resource.Id.cost_input);
            _occurenceSpinner = FindViewById<Spinner>(Resource.Id.occurence_spinner);
        }

        bool InputFieldsValidationFailureStatus()
        {
            bool AllFieldsInputValidationFailureStatus = false;

            if (string.IsNullOrEmpty(_billNameField.Text))
            {
                _billNameField.SetError("Username cannot be blank ...", null);
                AllFieldsInputValidationFailureStatus = true;
            }

            if (string.IsNullOrEmpty(_billDescriptionField.Text))
            {
                _billDescriptionField.SetError("Description cannot be blank ...", null);
                AllFieldsInputValidationFailureStatus = true;
            }

            if (string.IsNullOrEmpty(_billCostField.Text))
            {
                _billCostField.SetError("Cost cannot be blank ...", null);
                AllFieldsInputValidationFailureStatus = true;
            }

            return AllFieldsInputValidationFailureStatus;
        }
    }
}
