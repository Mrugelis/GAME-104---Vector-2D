using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game_104_Vector2D
{
    class Program
    {
        static void Main(string[] args)
        {
            double xA, yA, xB, yB, mag, angle;
            double scalar = 3;
            bool run = true;
            bool response = true;
            string entry;
            Vector2D A = new Vector2D(xA, yA);
            Vector2D B = new Vector2D(xB, yB);

            Console.WriteLine("This is vector A, x = {0} y = {1}", A.X, A.Y);
            Console.WriteLine("This is vector B, x = {0} y = {1}", B.X, B.Y);
            A.ScalarMultiplication(scalar);
            mag = A.GetMagnitude();
            angle = A.GetAngleInDegrees();
            Console.WriteLine("This is the scalar multiple of the vector by {0} , x = {1} y = {2}", scalar, A.X, A.Y);
            Console.WriteLine("This is the angle in degrees: {0}", angle);
            Console.WriteLine("This is the magnitude: {0}", mag);


            do
            {
                Console.WriteLine("This is vector A, x = {0} y = {1}", A.X, A.Y);
                //Double.Parse(Console.Readline());



                do
                {
                    Console.WriteLine("Would you like to continue doing vector operations? y/n");
                    entry = Console.ReadLine();
                     if (entry == "n" || entry == "N")
                    {
                        run = false;
                        response = true;
                    }
                    else if (entry == "y" || entry == "Y")
                    {
                        run = true;
                        response = true;
                    }
                    else
                    {
                        response = false;

                    }
                } while (response == false);
               
            } while (run == true);
            
        }
    }
}
