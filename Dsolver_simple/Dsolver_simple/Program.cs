using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dsolver_simple
{
    class Program
    {
        static double F(double x, double v)// Declaration of one or many differential equations as single functions of the arguments (x,y).
        {
            return  -v-x;
        }
        static double G(double x,double v)
        {
            return v;
        }
        static void Main(string[] args)
        {// User input of parameters from intial conditions x0, y0, step size h and number of steps N.           
            Console.WriteLine("Ordinary differential equations (ODE) solver.\nEnter initial conditions: ");
            //Console.WriteLine("t0= ");
            //double t = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("x0= ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("v0= ");
            double v = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter step size:\nh= ");
            double h = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter number of steps:\nN= ");
            double N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Results using the Euler´s method:\nt\t x(t)\t v(t) ");
            //To store the values of the Euler´s algorithm in a .txt file:
            // Set a variable "pfad" to the Document´s path.
            string pfad = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write result to a new file named "gauss.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(pfad, "gauss2.txt")))
            {
                for (int i = 0; i < N; i++)
                {
                    h = (h == 0) ? 0.1 : h;// The ternary operator is used here to avoid type 0/0 singularities.  
                    double t = i * h;// The instrinsic time parameter corresponds to the consecutive sum of steps of size "h".
                    double vn = v + F(x, v) * h;
                    double xn = x + G(x, v) * h;
                    //double tn = t + h;                    
                    v = vn;
                    x = xn;
                    //t = tn;
                    outputFile.WriteLine("{0:n3}\t{1:n3}\t{2:n3}",t, x, v);// The file output is given columns with a limited number of floating points.
                    Console.WriteLine("{0:n3}\t{1:n3}\t{2:n3}", t, x, v);//Display result in the console for verification.
                }
            }
                
            Console.ReadLine();// This is only to keep the console 'alive' after the evaluation.

        }
    }
}
