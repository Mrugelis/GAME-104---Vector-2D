using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game_104_Assignment
{
    class Vector2D
    {
        private double x;
        private double y;

        //gets and sets the X value of a Vector2D
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

        //gets and sets the Y value of a Vector2D
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

        //Creates a new Vector2D with fields xValue and yValue
        public Vector2D(double xValue, double yValue)
        {
            X = xValue;
            Y = yValue;
        }

        //Negates the x value of a Vector2D
        public void NegateX()
        {
            X *= -1;
        }

        //Negates the y value of a Vector2D
        public void NegateY()
        {
            Y *= -1;
        }
    
        //Adds two Vector2D x and y components together to get the resulting addition vector
        public void AddVector(double xValue, double yValue)
        {
            Y += yValue;
            X += xValue;         
        }
        
        //Subtracts two Vector2D x and y components to get the resulting addition vector
        public void SubtractVector(double xValue, double yValue)
        {
            Y -= yValue;
            X -= xValue;     
        }

        //Scales the x and y components of a Vector2D by a factor of scalar
        public void ScalarMultiplication(double scalar)
        {
            Y *= scalar;
            X *= scalar;        
        }

        //Gets the magnitude of a Vector2D
        public double GetMagnitude()
        { 
            return Math.Sqrt((X * X) + (Y * Y));
        }

        //Gets the position angle of a Vector2D in degrees
        public double GetAngleInDegrees()
        {
            // For (x, y) in quadrant 1, 0 < θ < π/2.
            // For(x, y) in quadrant 2, π / 2 < θ≤π.
            // For(x, y) in quadrant 3, -π < θ < -π / 2.
            // For(x, y) in quadrant 4, -π / 2 < θ < 0.

            return Math.Atan2(X, Y) * (180 / Math.PI);
        }

        //Normalizes a Vector2D, where the resulting normal Vector2D has the same direction but a magnitude of 1
        public void Normalize()
        {
            X /= GetMagnitude();
            Y /= GetMagnitude();        
        }

        //Gets the dot product of two Vector2D objects
        public double GetDotProduct(Vector2D otherVector)
        {
            return ((X * otherVector.X) + (Y * otherVector.Y));
        }

        //Gets the angle between two Vector2D objects in radians
        public double GetAngleBetweenVector(Vector2D otherVector)
        {
            return Math.Acos(GetDotProduct(otherVector) / (GetMagnitude() * otherVector.GetMagnitude()));
        }

        //Finds the linear interpolation Vector2D between two Vector2D objects
        //Using t, to determine the position of the linear interpolation vector is oriented between the two Vector2D objects
        //t=0 LerpVector = Vector2D being used to call the method Lerp(otherVector,t) , t=1 LerpVector = otherVector
        public void Lerp(Vector2D otherVector, double t)
        {
            //0 <=  t <= 1
            //New vector = (1 - t)A + tB
            //A-tA + tB
            if(0 <= t && t <= 1)
            {
                Vector2D scaledVA = new Vector2D(X, Y);
                Vector2D scaledVB = new Vector2D(otherVector.X, otherVector.Y);
                scaledVA.ScalarMultiplication(t);
                scaledVB.ScalarMultiplication(t);
                SubtractVector(scaledVA.X, scaledVA.Y);
                AddVector(scaledVB.X, scaledVB.Y);
            }
            else
            {
                Console.WriteLine("Invalid value for t");
            }
        }

        //rotates a Vector2D by angle, angle in radians
        public void RotateVector(double angle)
        {
            double rotatedX = X * Math.Cos(angle) - Y * Math.Sin(angle);
            double rotatedY = X * Math.Sin(angle) + Y * Math.Cos(angle);
            X = rotatedX;
            Y = rotatedY;
        }
    }
}
