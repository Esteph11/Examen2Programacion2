using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace Examen_Mvvm.ViewModels
{
    public partial class ProductosViewModel : ObservableObject
    {
        [ObservableProperty]
        private double producto1;

        [ObservableProperty]
        private double producto2;

        [ObservableProperty]
        private double producto3;

        [ObservableProperty]
        public double subtotal;

        [ObservableProperty]
        private double descuento;

        [ObservableProperty]
        private double totalpagar;

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        public void Calcular()
        {
            try
            {
                    Subtotal = Producto1 + Producto2 + Producto3;
                    Descuento = CalcularDescuento(Subtotal);
                    Totalpagar = Subtotal - Descuento;

                if (Descuento == 0)
                {
                    Alerta("AVISO", "Su total no aplica descuento");
                }
                else
                { 
                if (Descuento > 0.10)
                    Alerta("ATENCIÓN", "Su total aplica descuento");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        [RelayCommand]
        public void Limpiar()
        {
            Producto1 = 0;
            Producto2 = 0;
            Producto3 = 0;
            Subtotal = 0;
            Descuento = 0;
            Totalpagar = 0;
        }

        private double CalcularDescuento(double totaldes)
        {
            if (totaldes < 1000)
                return 0;
            else if (totaldes < 5000)
                return totaldes * 0.10;
            else if (totaldes < 10000)
                return totaldes * 0.20;
            else
                return totaldes * 0.30;
        }
    }
}
