using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game_104_Vector2D
{
    class Vector2D
    {
        double x;
        double y;

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public Vector2D(double xValue, double yValue)
        {
            X = xValue;
            Y = yValue;
        }

        public void NegateX()
        {
            X *= -1;
        }

        public void NegateY()
        {
            Y *= -1;
        }
    

        public Vector2D AddVector(double xValue, double yValue)
        {
            double addY = Y + yValue;
            double addX = X + xValue;
            Vector2D addV = new Vector2D(addX, addY);
            
            return addV;            
        }

        public Vector2D SubtractVector(double xValue, double yValue)
        {
            double subtractY = Y - yValue;
            double subtractX = X - xValue;
            Vector2D subtractV = new Vector2D(subtractX, subtractY);
            
            return subtractV;
        }

        public Vector2D ScalarMultiplication(double scalar)
        {

            double scalarY = Y * scalar;
            double scalarX = X * scalar;
            Vector2D scalarV = new Vector2D(scalarX, scalarY);
            
            return scalarV;           
        }

        public double GetMagnitude()
        { 
            return Math.Sqrt((X * X) + (Y * Y));
        }

        public double GetAngleInDegrees()
        {
            // For (x, y) in quadrant 1, 0 < θ < π/2.
            // For(x, y) in quadrant 2, π / 2 < θ≤π.
            // For(x, y) in quadrant 3, -π < θ < -π / 2.
            // For(x, y) in quadrant 4, -π / 2 < θ < 0.

            return Math.Atan2(X, Y) * (180 / Math.PI);
        }

        //past this is assigment part 2
        public Vector2D Normalize()
        {
            //Divide the vector by it’s magnitude. 
            //This ensures that the vector magnitude 
            //is equal to one 
            double normalX =  X / GetMagnitude();
            double normalY =  Y / GetMagnitude();
            Vector2D normalV = new Vector2D(normalX, normalY);
           
            return normalV;

        }

        public double GetDotProduct(Vector2D otherVector)
        {
            //If vector A = [ax, ay] and vector B = [bx, by], 
            //then A·B = axbx + ayby

            return ((X * otherVector.X) + (Y * otherVector.Y));
        }

        public double GetAngleBetweenVector(Vector2D otherVector)
        {
            //Rearrange the equation A·B = | A || B | cosƟ to return Ɵ
            //(where | A | is the magnitude of vector A and | B | is the magnitude of vector B) 

            return Math.Acos(GetDotProduct(otherVector) / (GetMagnitude() * otherVector.GetMagnitude()));
        }

        public Vector2D Lerp(Vector2D otherVector, double t)
        {
            // 0<= t <= 1
            //New vector = (1 - t)A + tB

            return SubtractVector(ScalarMultiplication(t).X, ScalarMultiplication(t).Y).AddVector(otherVector.ScalarMultiplication(t).X, otherVector.ScalarMultiplication(t).Y);


        }

        public Vector2D RotateVector(double angle)
        {
            //Rotate the vector by angle Ɵ using the following equations:
            //New x = x cos Ɵ – y sin Ɵ
            //New y = x sin Ɵ +y cos Ɵ
            
            double rotatedX = X * Math.Cos(angle) - Y * Math.Sin(angle);
            double rotatedY = X * Math.Sin(angle) + Y * Math.Cos(angle);
            
            Vector2D rotatedV = new Vector2D(rotatedX, rotatedY);
            
            return rotatedV;
        }
    }
}
