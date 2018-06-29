using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App05_ControlesXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EntryEditorPage : ContentPage
	{
		public EntryEditorPage ()
		{
			InitializeComponent ();

            TxtIdade.TextChanged += delegate (object sender, TextChangedEventArgs args)
            {
                lblDuplicado.Text = args.NewTextValue;
            };

            TxtComentario.Completed += delegate(object sender, EventArgs args)
            {
                lblQtdeCaracteres.Text = TxtComentario.Text.Length.ToString();
            };
		}
	}
}