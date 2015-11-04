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
            //gets and sets x value of a Vector2D
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
            //gets and sets y value of a Vector2D
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
            //Instantiates new Vector2D with x and y values
            X = xValue;
            Y = yValue;
        }

        public void NegateX()
        {
            //Negates X value of Vector2D
            X *= -1;
        }

        public void NegateY()
        {
            //Negates Y value of Vector2D
            Y *= -1;
        }
    

        public Vector2D AddVector(double xValue, double yValue)
        {
            //Adds two Vector2D and returns the resultant Vector2D
            double addY = Y + yValue;
            double addX = X + xValue;
            Vector2D addV = new Vector2D(addX, addY);
            
            return addV;            
        }

        public Vector2D SubtractVector(double xValue, double yValue)
        {
            //Subtracts two Vector2D and returns the resultant Vector2D
            double subtractY = Y - yValue;
            double subtractX = X - xValue;
            Vector2D subtractV = new Vector2D(subtractX, subtractY);
            
            return subtractV;
        }

        public Vector2D ScalarMultiplication(double scalar)
        {
            //Multiplies a Vector2D by a scalar and returns the resultant Vector2D
            double scalarY = Y * scalar;
            double scalarX = X * scalar;
            Vector2D scalarV = new Vector2D(scalarX, scalarY);
            
            return scalarV;           
        }

        public double GetMagnitude()
        { 
            //Returns the Magnitude of a Vector2D
            return Math.Sqrt((X * X) + (Y * Y));
        }

        public double GetAngleInDegrees()
        {
            // For (x, y) in quadrant 1, 0 < θ < π/2.
            // For(x, y) in quadrant 2, π / 2 < θ≤π.
            // For(x, y) in quadrant 3, -π < θ < -π / 2.
            // For(x, y) in quadrant 4, -π / 2 < θ < 0.
            //Returns the angle in degrees of a Vector2D
            
            return Math.Atan2(X, Y) * (180 / Math.PI);
        }

        //past this is assigment part 2
        public Vector2D Normalize()
        {
            //Divide a Vector2D by its magnitude to normalize its magnitude to 1
            
            
            double normalX =  X / GetMagnitude();
            double normalY =  Y / GetMagnitude();
            Vector2D normalV = new Vector2D(normalX, normalY);
           
            return normalV;

        }

        public double GetDotProduct(Vector2D otherVector)
        {
            //Returns the dot product between two Vector2D
            //A·B = axbx + ayby

            return ((X * otherVector.X) + (Y * otherVector.Y));
        }

        public double GetAngleBetweenVector(Vector2D otherVector)
        {
            //Returns the angle between two Vector2D
            return Math.Acos(GetDotProduct(otherVector) / (GetMagnitude() * otherVector.GetMagnitude()));
        }

        public Vector2D Lerp(Vector2D otherVector, double t)
        {
            //Returns the linear interpolation vector of two Vector2D
            // 0<= t <= 1
            //New vector = (1 - t)A + tB

            return SubtractVector(ScalarMultiplication(t).X, ScalarMultiplication(t).Y).AddVector(otherVector.ScalarMultiplication(t).X, otherVector.ScalarMultiplication(t).Y);


        }

        public Vector2D RotateVector(double angle)
        {
            //Returns a rotated Vector2D
            //New x = x cos Ɵ – y sin Ɵ
            //New y = x sin Ɵ +y cos Ɵ
            
            double rotatedX = X * Math.Cos(angle) - Y * Math.Sin(angle);
            double rotatedY = X * Math.Sin(angle) + Y * Math.Cos(angle);
            
            Vector2D rotatedV = new Vector2D(rotatedX, rotatedY);
            
            return rotatedV;
        }
    }
}
