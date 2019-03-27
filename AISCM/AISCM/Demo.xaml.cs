using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AISCM
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Demo : ContentPage
    {
        public Demo()
        {
            InitializeComponent();
        }

        private void click_link1(object sender, EventArgs e)
        {
            Uri url = new Uri("http://krishi.maharashtra.gov.in/Site/Upload/Pdf/Website%20Information%20Adarshgaon%20%20Yojana.pdf");
            System.Diagnostics.Debug.WriteLine("Url before..."+url);
            Device.OpenUri(url);
        }
        private void click_link2(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://krishi.maharashtra.gov.in/Site/Upload/Pdf/Dr_BAKSY.pdf"));
        }
        private void click_link3(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://krishi.maharashtra.gov.in/Site/Upload/Pdf/TSP_scheme.pdf"));
        }
        private void click_link4(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://krishi.maharashtra.gov.in/Site/Upload/Pdf/OTSP_scheme.pdf"));
        }
        private void click_link5(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://krishi.maharashtra.gov.in/Site/Upload/Pdf/evalution%20report%202018.pdf"));
        }
    }

    
}
