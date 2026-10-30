using System;

namespace CalculoInteresCompuesto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MÓDULO DE CAPITALIZACIÓN RECURSIVA");

            // Captura de datos con validaciones para aceptar valores decimales
            Console.Write("Ingrese el capital inicial depositado (m): $");
            if (!decimal.TryParse(Console.ReadLine(), out decimal capitalInicial) || capitalInicial < 0)
            {
                Console.WriteLine("Error: El capital inicial debe ser un número positivo.");
                return;
            }

            Console.Write("Ingrese la tasa de interés anual en % (X): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal tasaInteres) || tasaInteres < 0)
            {
                Console.WriteLine("Error: La tasa de interés debe ser un valor positivo.");
                return;
            }

            Console.Write("Ingrese el tiempo de la inversión en años (n): ");
            if (!int.TryParse(Console.ReadLine(), out int anios) || anios < 0)
            {
                Console.WriteLine("Error: Los años de inversión no pueden ser negativos.");
                return;
            }

            // Ejecución de la lógica recursiva
            decimal montoFinal = CalcularInteresRecursivo(capitalInicial, tasaInteres, anios);

            Console.WriteLine("\n--- RESULTADO ---");
            Console.WriteLine($"El monto total acumulado después de {anios} años es: ${montoFinal:F2}");
        }

       
        static decimal CalcularInteresRecursivo(decimal m, decimal X, int n)
        {
            //Caso Base
            // Si no han transcurrido años (n=0), el monto acumulado es igual al capital inicial m
            if (n == 0)
            {
                return m;
            }

            //Caso Recursivo
            // C(n-1): Se invoca la función a sí misma pasando el año anterior (n-1)
            decimal montoAnterior = CalcularInteresRecursivo(m, X, n - 1);

            // La tasa de interés (X) se convierte a su equivalente decimal interno (i = X/100)
            decimal i = X / 100m;

            // Factor de crecimiento (1 + i).
            decimal factorCrecimiento = 1 + i;

            // C(n) = C(n-1) * (1 + i)
            return montoAnterior * factorCrecimiento;
        }
    }
}