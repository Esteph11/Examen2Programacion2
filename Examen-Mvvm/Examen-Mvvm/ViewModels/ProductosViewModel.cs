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
                if (Subtotal < 1000)
                {
                    Subtotal = Producto1 + Producto2 + Producto3;
                    Descuento = 0;
                    Totalpagar = Subtotal - Descuento;

                    Alerta("ADVERTENCIA", "Valor de a no debe ser cero");
                }
                else if (Subtotal < 5000)
                {
                    Subtotal = Producto1 + Producto2 + Producto3;
                    Descuento = Subtotal * 0.10;
                    Totalpagar = Subtotal - Descuento;
                }
                else if (Subtotal < 10000)
                {
                    Subtotal = Producto1 + Producto2 + Producto3;
                    Descuento = Subtotal * 0.20;
                    Totalpagar = Subtotal - Descuento;
                }
                else if (Subtotal < 10000)
                {
                    Subtotal = Producto1 + Producto2 + Producto3;
                    Descuento = Subtotal * 0.20;
                    Totalpagar = Subtotal - Descuento;
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

    }
}
