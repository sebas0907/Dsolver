using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;



namespace DSolver
{

    class Program
    {
        public delegate double Function(double x, double y);
        static double f(double x, double y)
        { return  -y*x; }
        public static double Dsolve(Function f, double x0, double y0, double h, double x)
        {
            // Implementation of numerical routine for the Euler´s method
            h = (h == 0) ? 0.001 : h;// The ternary operator is used here to avoid singularities.
            double xn, yn, result = double.NaN; //Initializing variables
            if (x <= x0) result = y0;
            else if (x > x0)
            {
                do
                {
                    if (h > x - x0) h = x - x0;
                    yn = y0 + f(x0, y0) * h;
                    xn = x0 + h;
                    x0 = xn;
                    y0 = yn;
                } while (x0 < x);
                result = yn;
            }
            return result;
        }
        
        static void Main(string[] args)
        {
            // User input of parameters from intial conditions x0, y0, step size h and number of steps N.
            Console.WriteLine("Enter Intitial Conditions: ");
            Console.WriteLine("x0= ");
            double x0 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("y0= ");
            double y0 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter step size");
            double h = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter number of steps: ");
            double N = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Numerical Results with the Euler´s method:\n x\t y(x) ");
            double result = y0;
            
                   // Set a variable to the Documents path.
                    string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    // Write result to a new file named "sol.txt".
                   using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "sol2.txt")))
                  {
                    for(int i = 0; i < N; i++)
                    {
                        double x = 0.1 * i;
                        result = Dsolve(f, x0, result, h, x);
                   // The file output is given in two columns with a limited number of floating points.
                        outputFile.WriteLine("{0:n1}\t{1:n3}", x, result);
                    //Display result in the console for verification.
                    Console.WriteLine("{0:n1}\t{1:n3}", x, result);
                        x0 = x;                  
                     }                                      
                  }

            
            Console.ReadLine();// This is only to keep the console 'alive' after the evaluation.
            
            
        }
    }
}
