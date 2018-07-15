using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App05_ControlesXF.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{
		public Master ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "ActivityIndicator")
            {
                Detail = new NavigationPage(new Controles.ActivityIndicatorPage());
                this.IsPresented = false;
            } 
            else if (((Button)sender).Text == "ProgressBar")
            {
                Detail = new NavigationPage(new Controles.ProgressBarPage());
                this.IsPresented = false;
            }
            else if (((Button)sender).Text == "BoxView")
            {
                Detail = new NavigationPage(new Controles.BoxViewPage());
                this.IsPresented = false;
            }
            else if (((Button)sender).Text == "Label")
            {
                Detail = new NavigationPage(new Controles.LabelPage());
                this.IsPresented = false;
            }
            else if (((Button)sender).Text == "Button")
            {
                Detail = new NavigationPage(new Controles.ButtonPage());
                this.IsPresented = false;
            }
            else if (((Button)sender).Text == "EntryEditor")
            {
                Detail = new NavigationPage(new Controles.EntryEditorPage());
                this.IsPresented = false;
            }
            else if (((Button)sender).Text == "DatePicker")
            {
                Detail = new NavigationPage(new Controles.DatePickerPage());
                this.IsPresented = false;
            }
            else if (((Button)sender).Text == "TimePicker")
            {
                Detail = new NavigationPage(new Controles.TimePickerPage());
                this.IsPresented = false;
            }
            else if (((Button)sender).Text == "Picker")
            {
                Detail = new NavigationPage(new Controles.PickerPage());
                this.IsPresented = false;
            }
            else if (((Button)sender).Text == "SearchBar")
            {
                Detail = new NavigationPage(new Controles.SearchBarPage());
                this.IsPresented = false;
            }
            else if (((Button)sender).Text == "Switch")
            {
                Detail = new NavigationPage(new Controles.SwitchPage());
                this.IsPresented = false;
            }
            else if (((Button)sender).Text == "Image")
            {
                Detail = new NavigationPage(new Controles.ImagePage());
                this.IsPresented = false;
            }
            else if (((Button)sender).Text == "ListView")
            {
                Detail = new NavigationPage(new Controles.ListViewPage());
                this.IsPresented = false;
            }
            else if (((Button)sender).Text == "TableView")
            {
                Detail = new NavigationPage(new Controles.TableViewPage());
                this.IsPresented = false;
            }
            else if (((Button)sender).Text == "WebView")
            {
                Detail = new NavigationPage(new Controles.WebViewPage());
                this.IsPresented = false;
            }
        }
    }
}