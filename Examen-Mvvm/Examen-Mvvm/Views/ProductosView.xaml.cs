using Examen_Mvvm.ViewModels;

namespace Examen_Mvvm.Views;

public partial class ProductosView : ContentPage
{
    private ProductosViewModel ViewModel;
    public ProductosView()
    {
        InitializeComponent();
        ViewModel = new ProductosViewModel();
        BindingContext = ViewModel;
    }
}