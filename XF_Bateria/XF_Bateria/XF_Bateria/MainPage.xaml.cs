using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Battery;

namespace XF_Bateria
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void BtnBateria_Clicked(object sender, EventArgs e)
        {
            if (CrossBattery.IsSupported)
            {
                var falta = CrossBattery.Current.RemainingChargePercent;
                lblInfo.Text = $"Percentual : {falta.ToString()}%\n";

                var status = CrossBattery.Current.Status;
                lblInfo.Text += $"Status :{status.ToString()}\n";

                var source = CrossBattery.Current.PowerSource;
                lblInfo.Text += $"Media : {source.ToString()}\n\n";

                CrossBattery.Current.BatteryChanged -= Current_BatteryChanged;
                CrossBattery.Current.BatteryChanged += Current_BatteryChanged;
            }
        }

        private void Current_BatteryChanged(object sender, Plugin.Battery.Abstractions.BatteryChangedEventArgs e)
        {
            lblStatus.Text = "STATUS ATUAL: " + e.Status.ToString() + "\n";
            lblStatus.Text += "Nivel da BATERIA baixo : " + e.IsLow.ToString();
        }
    }
}
