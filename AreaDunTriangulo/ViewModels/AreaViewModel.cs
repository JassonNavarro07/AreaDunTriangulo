using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AreaDunTriangulo.ViewModels
{
    partial class AreaViewModel : ObservableObject
    {

        [ObservableProperty]
        public string lado1;
        [ObservableProperty]
        public string lado2;
        [ObservableProperty]
        public string lado3;
        [ObservableProperty]
        public string resultado;


        [RelayCommand]
        private void CalcularArea()
        {
            if (double.TryParse(Lado1, out double la1) &&
                double.TryParse(Lado2, out double la2) &&
                double.TryParse(Lado3, out double la3))
            {
                // Verificar si los lados forman un triángulo válido
                if (la1 + la2 > la3 && la1 + la3 > la2 && la2 + la3 > la1)
                {
                    // Calcular el semiperímetro
                    double s = (la1 + la2 + la3) / 2;

                    // Calcular el área usando la fórmula de Herón
                    double area = Math.Sqrt(s * (s - la1) * (s - la2) * (s - la3));

                    // Mostrar el resultado
                    Resultado = $"Área: {area:F2}";
                }
                else
                {
                    Resultado = "Los lados proporcionados no forman un triángulo válido.";
                }
            }
            else
            {
                Resultado = "Ingrese números válidos para los lados.";
            }
        }
    }
}
