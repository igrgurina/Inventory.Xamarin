using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.XForms.PopupLayout;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupPage : SfPopupLayout
    {
        public PopupPage()
        {
            InitializeComponent();
        }
    }
}