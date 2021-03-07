using System;
namespace ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double heihght)
        {
            Length  = length;
            Width   = width;
            Height = heihght;
        }
        private double Length 
        {
            set 
            {
                ValidateProp(value, "Length");
                length = value; 
            } 
        }
        private double Width
        {
            set
            {
                ValidateProp(value, "Width");
                width = value;
            }
        }
        private double Height
        {
            set
            {
                ValidateProp(value, "Height");
                height = value;
            }
        }
        private void ValidateProp(double value, string side)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{side} cannot be zero or negative.");
            }
        }
        public double SurfaceArea => LateralSurfaceArea + length * width * 2;
        public double LateralSurfaceArea => (length + width) * height * 2;
        public double Volume => length * width * height;
    }
}
