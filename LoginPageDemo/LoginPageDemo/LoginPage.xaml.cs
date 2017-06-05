using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginPageDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            OnLoginPageSizeChanged(null,null);
        }

        private void OnLoginPageSizeChanged(object sender, EventArgs e)
        {
            // Daha default value'leri degismedi. O yuzden herhangi bir degisiklige
            // gerek yok.
            if(Width*Height < 0) return;
            
            if (Width < Height)
            {
                // Potrait
                MainGrid.RowDefinitions[0].Height = new GridLength(1,GridUnitType.Star);
                MainGrid.RowDefinitions[1].Height = new GridLength(1,GridUnitType.Star);
                MainGrid.ColumnDefinitions[0].Width= new GridLength(1,GridUnitType.Star);
                MainGrid.ColumnDefinitions[1].Width = new GridLength(0,GridUnitType.Star);
                
                Grid.SetRow(ContentStacklayout,1);
                Grid.SetColumn(ContentStacklayout,0);
            }
            else
            {
                //Landscape
                MainGrid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                MainGrid.RowDefinitions[1].Height = new GridLength(0, GridUnitType.Star);
                MainGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                MainGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);

                Grid.SetRow(ContentStacklayout, 0);
                Grid.SetColumn(ContentStacklayout, 1);
            }
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            
            Debug.WriteLine("*******************************");
        }
    }
}
