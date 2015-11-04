using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_104_Assignment
{
    class Matrix2x2
    {
        private Vector2D column1;
        private Vector2D column2;

        public Vector2D Column1
        {
            get
            {
                return column1;
            }
            set
            {
                column1 = value;
            }
        }
        public Vector2D Column2
        {
            get
            {
                return column2;
            }
            set
            {
                column2 = value;
            }
        }

        public Matrix2x2(Vector2D col1, Vector2D col2)
        {
            Column1 = col1;
            Column2 = col2;
        }

        public Matrix2x2(double e11, double e12, double e21, double e22)
        {
            Vector2D col1 = new Vector2D(e11, e21);
            Vector2D col2 = new Vector2D(e12, e22);
            Column1 = col1;
            Column2 = col2;

        }


        public void SetMatrix(Vector2D col1, Vector2D col2)
        {
            Column1 = col1;
            Column2 = col2;
        }

        public void SetRotationMatrixInDegrees(double angle)
        {
            angle *= Math.PI / 180.0;
            Vector2D col1 = new Vector2D(Math.Cos(angle), Math.Sin(angle));
            Vector2D col2 = new Vector2D(-Math.Sin(angle), Math.Cos(angle));
            SetMatrix(col1, col2);
        }
        public void SetScalingMatrix(double scaleX, double scaleY)
        {
            Vector2D col1 = new Vector2D(scaleX, 0);
            Vector2D col2 = new Vector2D(0, scaleY);
            SetMatrix(col1, col2);
        }
        public void SetIdentityMatrix()
        {
            Vector2D col1 = new Vector2D(1.0, 0.0);
            Vector2D col2 = new Vector2D(0.0, 1.0);
            SetMatrix(col1, col2);
        }
        public void AddMatrix(Matrix2x2 otherMatrix)
        {
            Vector2D col1 = new Vector2D((Column1.X + otherMatrix.Column1.X), (Column1.Y + otherMatrix.Column1.Y));
            Vector2D col2 = new Vector2D((Column2.X + otherMatrix.Column2.X), (Column2.Y + otherMatrix.Column2.Y));
            SetMatrix(col1, col2);
        }
        public void SubtractMatrix(Matrix2x2 otherMatrix)
        {
            Vector2D col1 = new Vector2D((Column1.X - otherMatrix.Column1.X), (Column1.Y - otherMatrix.Column1.Y));
            Vector2D col2 = new Vector2D((Column2.X - otherMatrix.Column2.X), (Column2.Y - otherMatrix.Column2.Y));
            SetMatrix(col1, col2);
        }

        public void WriteMatrix()
        {
            Console.WriteLine("Matrix is:");
            Console.WriteLine("|" + Column1.X + "  ,  " + Column2.X + "|");
            Console.WriteLine("|" + Column1.Y + "  ,  " + Column2.Y + "|");
        }

        public Matrix2x2 MultiplyMatrix(Matrix2x2 otherMatrix)
        {
            double e11 = Column1.X * otherMatrix.Column1.X + Column2.X * otherMatrix.Column1.Y;
            double e12 = Column1.X * otherMatrix.Column2.X + Column2.X * otherMatrix.Column2.Y;
            double e21 = Column1.Y * otherMatrix.Column1.X + Column2.Y * otherMatrix.Column1.Y;
            double e22 = Column1.Y * otherMatrix.Column2.X + Column2.Y * otherMatrix.Column2.Y;

            Matrix2x2 newMatrix = new Matrix2x2(e11, e12, e21, e22);
            return newMatrix;
        }

        public void Transpose()
        {
            double e12 = Column1.Y;
            double e21 = Column2.X;
            Column2.X = e12;
            Column1.Y = e21;
        }

        public double GetDeterminant()
        {
           return (Column1.X * Column2.Y) - (Column2.X * Column1.Y);
        }

        public void Inverse()
        {
            double d = GetDeterminant();
            Column2.NegateX();
            Column1.NegateY();
            double ie11 = Column2.Y / d;
            double ie12 = Column2.X / d;
            double ie21 = Column1.Y / d;
            double ie22 = Column1.X / d;

            Vector2D invCol1 = new Vector2D(ie11, ie21);
            Vector2D invCol2 = new Vector2D(ie12, ie22);

            SetMatrix(invCol1, invCol2);
        }
    }
}
