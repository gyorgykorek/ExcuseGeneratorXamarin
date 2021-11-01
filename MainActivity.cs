using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Android.Widget;
using Android.Content;

namespace excuserandomgenerator
{


    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
       
        Button button1; // generálás
        TextView textView3; //bullshitek
        TextView textView4;
        TextView textView6; //simplifyit leírás
        TextView textView7; //írjatok leírás
        Spinner spinner1;
        ImageButton imageButton1;
        ImageButton imageButton2;
        string spinnervalue = "";

        //MÁSOLÁSHOZ
        ClipboardManager clipBoardManager;
        ClipData clipData;

        //objektum EXCUSES
        excuses newClassObj = new excuses();




        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            textView3 = FindViewById<TextView>(Resource.Id.textView3);
            textView4 = FindViewById<TextView>(Resource.Id.textView4);
            textView6 = FindViewById<TextView>(Resource.Id.textView6);
            textView7 = FindViewById<TextView>(Resource.Id.textView7);
            spinner1 = FindViewById<Spinner>(Resource.Id.spinner1);


            button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Generate;

            imageButton1 = FindViewById<ImageButton>(Resource.Id.imageButton1);
            imageButton1.Click += ImageButton1_Click;

            imageButton2 = FindViewById<ImageButton>(Resource.Id.imageButton2);
            imageButton2.Click += ImageButton2_Click;


            spinner1.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner1_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.dropdown_arrays, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner1.Adapter = adapter;

            //MÁSOLÁS
            clipBoardManager = (ClipboardManager)GetSystemService(ClipboardService);
            textView3.Click += TextView3_Click;
            //Credit üzi
            Toast.MakeText(this, "Developed by György Korek", ToastLength.Long).Show();

        }

        //MÁSOLÁS
        private void TextView3_Click(object sender, EventArgs e)
        {
            if (textView4.Text == "\nChange language: ENG\n")
            {
                String text = textView3.Text;
                clipData = ClipData.NewPlainText("text", text);
                clipBoardManager.PrimaryClip = clipData;

                Toast.MakeText(this, "Kimásoltad a bullsh*tet!", ToastLength.Short).Show();
            }
            else
            {
                String text = textView3.Text;
                clipData = ClipData.NewPlainText("text", text);
                clipBoardManager.PrimaryClip = clipData;

                Toast.MakeText(this, "You copied the bullsh*t!", ToastLength.Short).Show();
            }
                
        }


        //magyar gomb
        private void ImageButton2_Click(object sender, EventArgs e)
        {
            if (textView4.Text == "\nChange language: HUN\n")
            {
                textView4.Text = "\nChange language: ENG\n";
                textView6.Text = "Széleskörű IT szolgáltató elérhető áron!";
                textView7.Text = "Szívesen látnád a saját kifogásod? Írj az info@simplifyit.hu-ra!";
                textView3.Text = "Kezdhetjük a bullsh*tek gyártását?";
                button1.Text = "Kifogás generálás";
                var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.dropdown_arrays, Android.Resource.Layout.SimpleSpinnerItem);
                adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                spinner1.Adapter = adapter;

            }
        }
        //angol gomb
        private void ImageButton1_Click(object sender, EventArgs e)
        {
            
            if (textView4.Text == "\nChange language: ENG\n")
            {
                textView4.Text = "\nChange language: HUN\n";
                textView6.Text = "Complete IT service provider at an affordable price!";
                textView7.Text = "Would you like to see your excuse?Send to: info@simplifyit.hu!";
                textView3.Text = "Can we start making bullsh*ts?";
                button1.Text = "Generate excuse";
                var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.dropdown_arrays_eng, Android.Resource.Layout.SimpleSpinnerItem);
                adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                spinner1.Adapter = adapter;

            }

        }

        private void spinner1_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner1 = (Spinner)sender;
            spinnervalue = string.Format("{0}", spinner1.GetItemAtPosition(e.Position));
            if (spinnervalue == "Válassz kategóriát!") {
                textView3.Text = "Kezdhetjük a bullsh*tek gyártását?";
            }
            
            
        }

        private void Generate(object sender, EventArgs e)
        {
            //IT-HUN
            if (spinnervalue == "Informatika - Programozás") {
                Random random = new Random();
                int start2 = random.Next(0, newClassObj.itexcuse.Length);
                textView3.Text = newClassObj.itexcuse[start2];
            }
            //LATE-HUN
            else if (spinnervalue == "Miért késtem?")
            {
                Random random = new Random();
                int start2 = random.Next(0, newClassObj.kesesexcuse.Length);
                textView3.Text = newClassObj.kesesexcuse[start2];
            }
            //GAZDTUD-HUN
            else if (spinnervalue == "Gazdaságtudományok") {
                Random random = new Random();
                int start3 = random.Next(0, newClassObj.hrexcuse.Length);
                textView3.Text = newClassObj.hrexcuse[start3];
            }
            //CODHUN
            else if (spinnervalue == "COD: Warzone")
            {
                Random random = new Random();
                int start4 = random.Next(0, newClassObj.codexcuse.Length);
                textView3.Text = newClassObj.codexcuse[start4];
            }
            else if (spinnervalue == "Miért nem edzek ma?")
            {
                Random random = new Random();
                int start5 = random.Next(0, newClassObj.trainingexcuse.Length);
                textView3.Text = newClassObj.trainingexcuse[start5];
            }
            //lawhun
            else if (spinnervalue == "Jogi")
            {
                Random random = new Random();
                int start6 = random.Next(0, newClassObj.lawexcuse.Length);
                textView3.Text = newClassObj.lawexcuse[start6];
            }
            //sleepHUN
            else if (spinnervalue == "Miért nem tudok nálad aludni?")
            {
                Random random = new Random();
                int start7 = random.Next(0, newClassObj.sleepoverexcuse.Length);
                textView3.Text = newClassObj.sleepoverexcuse[start7];
            }
            //deadline-hun
            else if (spinnervalue == "Miért nincs kész határidőre?")
            {
                Random random = new Random();
                int start8 = random.Next(0, newClassObj.deadlineexcuse.Length);
                textView3.Text = newClassObj.deadlineexcuse[start8];
            }
            //training-hun
            else if (spinnervalue == "Miért nem kezdem el ma?")
            {
                Random random = new Random();
                int start9 = random.Next(0, newClassObj.todayexcuse.Length);
                textView3.Text = newClassObj.todayexcuse[start9];
            }
            //műszaki-hun
            else if (spinnervalue == "Műszaki")
            {
                Random random = new Random();
                int start10 = random.Next(0, newClassObj.engineeringexcuse.Length);
                textView3.Text = newClassObj.engineeringexcuse[start10];
            }
            //művészet-hun
            else if (spinnervalue == "Művészet")
            {
                Random random = new Random();
                int start11 = random.Next(0, newClassObj.artexcuse.Length);
                textView3.Text = newClassObj.artexcuse[start11];
            }
            //művészet-hun
            else if (spinnervalue == "Orvos- és egészségtudomány")
            {
                Random random = new Random();
                int start12 = random.Next(0, newClassObj.healthexcuse.Length);
                textView3.Text = newClassObj.healthexcuse[start12];
            }
            //művészet-hun
            else if (spinnervalue == "Sporttudomány")
            {
                Random random = new Random();
                int start13 = random.Next(0, newClassObj.sportexcuse.Length);
                textView3.Text = newClassObj.sportexcuse[start13];
            }

            //ENGLISH SECTION START
            else if (spinnervalue == "Why was I late?")
            {
                Random random = new Random();
                int start14 = random.Next(0, newClassObj.lateENG.Length);
                textView3.Text = newClassObj.lateENG[start14];
            }
            else if (spinnervalue == "Why isn´t it ready by the deadline?")
            {
                Random random = new Random();
                int start15 = random.Next(0, newClassObj.deadlineENG.Length);
                textView3.Text = newClassObj.deadlineENG[start15];
            }
            else if (spinnervalue == "Why am I not training today?")
            {
                Random random = new Random();
                int start16 = random.Next(0, newClassObj.trainingENG.Length);
                textView3.Text = newClassObj.trainingENG[start16];
            }
            else if (spinnervalue == "Why can´t I sleep with you?")
            {
                Random random = new Random();
                int start17 = random.Next(0, newClassObj.sleepoverENG.Length);
                textView3.Text = newClassObj.sleepoverENG[start17];
            }
            else if (spinnervalue == "Economist - Business Sciences")
            {
                Random random = new Random();
                int start18 = random.Next(0, newClassObj.businessENG.Length);
                textView3.Text = newClassObj.businessENG[start18];
            }
            else if (spinnervalue == "IT - Computer Science")
            {
                Random random = new Random();
                int start19 = random.Next(0, newClassObj.itENG.Length);
                textView3.Text = newClassObj.itENG[start19];
            }
            else if (spinnervalue == "COD : Warzone")
            {
                Random random = new Random();
                int start20 = random.Next(0, newClassObj.codexcuseENG.Length);
                textView3.Text = newClassObj.codexcuseENG[start20];
            }



        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        private void Kifogas(object sender, EventArgs eventArgs)
        {
           

        }
    }
}
