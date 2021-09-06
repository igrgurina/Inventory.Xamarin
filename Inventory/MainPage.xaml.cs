using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.ViewModels;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;

namespace Inventory
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        //private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    detailGrid.BindingContext = e.ItemData;
        //}
    }
}
