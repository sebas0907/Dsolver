using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dsolver_RK4//solve a coupled spring-mass system:
{
        class Program
        {
            // Declaration of one or many differential equations as single functions of the arguments (x,v):
            static double F1(double x1, double x2)
            {
            return -2 * x1 + x2;
            //return -(1 - 2*M / R) / 2;
            }
            static double F2(double x1, double x2)
            {
            return x1 -2 * x2;
            //return -(100*M*(R-2*M)*(2*R-3*M)) / (48*Math.PI*R * R*(R*R*(R-2*M)+(R-M)/12*Math.PI));
            }
            static void Main(string[] args)
            {// User input of parameters from intial conditions x0, y0, step size h and number of steps N:         
                Console.WriteLine("Ordinary differential equations (ODE) solver.\nEnter initial conditions: ");
                Console.WriteLine("x1(0)= ");
                double x1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("x2(0)= ");
                double x2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("v1(0)= ");
                double v1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("v2(0)= ");
                double v2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter step size:\nh= ");
                double h = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter number of steps:\nN= ");
                int N = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Results using the Euler´s method:\nt\t x1(t)\t x2(t)\t v1(t)\t v2(t) ");
                //To store the values of the Euler´s algorithm in a .txt file:
                // Set a variable "pfad" to the Document´s path.
                string pfad = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Write result to a new file named "rk4.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(pfad, "spring.txt")))
                {
                    for (int i = 0; i < N; i++)
                    {
                        // The ternary operator is used here to avoid type 0/0 singularities:
                        h = (h == 0) ? 0.1 : h;
                        // The instrinsic time parameter corresponds to the consecutive sum of steps of size "h":
                        double t = i * h;
                        double k1 = F1(x1, x2) * h;
                        double k2 = F1(x1 + h / 2, x2 + k1 / 2) * h;
                        double k3 = F1(x1 + h / 2, x2 + k2 / 2) * h;
                        double k4 = F1(x1 + h, x2 + k3) * h;
                        double l1 = F2(x1, x2) * h;
                        double l2 = F2(x1 + h / 2, x2 + l1 / 2) * h;
                        double l3 = F2(x1 + h / 2, x2 + l2 / 2) * h;
                        double l4 = F2(x1 + h, x2 + l3) * h;
                    double v1n = v1 + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                    double v2n = v2 + (l1 + 2 * l2 + 2 * l3 + l4) / 6;
                    double x1n = x1 + v1 * h;
                    double x2n = x2 + v2 * h;
                    //double Rn = R + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                    //double Mn = M + (l1 + 2 * l2 + 2 * l3 + l4) / 6;
                        v1 = v1n;
                        v2 = v2n;
                        x1 = x1n;
                        x2 = x2n;
                        //R = Rn;
                        //M = Mn;
                    // The file output is given columns with a limited number of floating points:
                    outputFile.WriteLine("{0:n3}\t{1:n3}\t{2:n3}\t{3:n3}\t{4:n4}", t, x1, x2, v1, v2);
                    //outputFile.WriteLine("{0:n3}\t{1:n3}\t{2:n3}\t{3:n3}\t{4:n3}", u, R, M, k1/h, l1/h);
                    //Console.WriteLine("{0:n3}\t{1:n3}\t{2:n3}\t{3:n3}\t{4:n3}", u, R, M, k1/h, l1/h);
                    //Display result in the console for verification:
                    Console.WriteLine("{0:n3}\t{1:n3}\t{2:n3}\t{3:n3}\t{4:n4}", t, x1, x2, v1, v2);
                    }
                }
                // This is only to keep the console 'alive' after the evaluation:   
                Console.ReadLine();
            }
        }   
}
