using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Text;
using Android.Text.Style;
using Android.Graphics;

namespace ActionBarTest
{
    [Activity(Label = "ActionBarTest", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/ApplicationTheme")]
    public class TestActionBarActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.TestActionBarActivity);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            SpannableString s = new SpannableString("Test of font");

            // Typeface tf = Typeface.CreateFromAsset(Assets, "fonts/Roboto-Thin.ttf");

            TypefaceSpan robotoTFS = new TypefaceSpan("fonts/Roboto-Thin.ttf");

            s.SetSpan(robotoTFS, 0, s.Length(), SpanTypes.ExclusiveExclusive);
            
            // s.SetSpan(robotoTFS, 0, s.Length(), SpanTypes.ExclusiveExclusive);
            
            ActionBar actionBar = this.ActionBar;
            
            actionBar.TitleFormatted = s;

            actionBar.Show();

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.test_actionbar_menu, menu);
            //var menuItem = menu.FindItem(Resource.Id.menu_settings);

            return base.OnCreateOptionsMenu(menu);
        }
    }
}

