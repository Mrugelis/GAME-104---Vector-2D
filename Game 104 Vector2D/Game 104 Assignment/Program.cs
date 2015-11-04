using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game_104_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector2D vec1 = new Vector2D(1.0, 3.0);
            Vector2D vec2 = new Vector2D(2.0, 4.0);
            Vector2D vec3 = new Vector2D(1.0, 3.0);
            Vector2D vec4 = new Vector2D(3.0, 1.0);
            Matrix2x2 m = new Matrix2x2(vec1, vec2);
            Matrix2x2 n = new Matrix2x2(vec3, vec4);
            Matrix2x2 p;

            Console.WriteLine("m is");

            m.WriteMatrix();

            Console.WriteLine("n is");

            n.WriteMatrix();

            Console.WriteLine("Transpose matrix m");

            m.Transpose();
            m.WriteMatrix();

            Console.WriteLine("Add matrix m and n");

            m.AddMatrix(n);
            m.WriteMatrix();

            Console.WriteLine("subtract matrix m-n");
            m.SubtractMatrix(n);
            m.WriteMatrix();

            Console.WriteLine("Multiply m and n");

            p = m.MultiplyMatrix(n);
            p.WriteMatrix();

            m.SetScalingMatrix(4, 4);
            m.WriteMatrix();

            m.SetRotationMatrixInDegrees(60.0);
            m.WriteMatrix();

            m.SetIdentityMatrix();
            m.WriteMatrix();

            
            Console.ReadLine();

        }
    }
}
