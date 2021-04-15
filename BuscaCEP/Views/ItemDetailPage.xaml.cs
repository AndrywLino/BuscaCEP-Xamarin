using BuscaCEP.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BuscaCEP.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}