using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private const double SIDE_MIN_VALUE = 0.0;
        private const string INVALID_SIDE_MESSEGE = "{0} cannot be zero or negative.";
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Lenght = length;
            this.Width = width;
            this.Height = height;
        }
        private double Lenght
        {
            get => this.length;
            set
            {
                this.ValidateSide(value, nameof(this.Lenght));
                this.length = value;
            }
        }
        private double Width
        {
            get => this.width;
            set
            {
                this.ValidateSide(value, nameof(this.Width));
                this.width = value;
            }
        }
        private double Height
        {
            get => this.height;
            set
            {
                this.ValidateSide(value, nameof(this.Height));
                this.height = value;
            }
        }

        private void ValidateSide(double value, string side)
        {
            if (value <= SIDE_MIN_VALUE)
            {
                throw new ArgumentException(String.Format(INVALID_SIDE_MESSEGE, side));
            }
        }

        public double SurfaceArea()
        {
            double area = 2 * (this.Lenght * this.Width) + 2 * (this.Lenght * this.Height) + 2 * (this.Width * this.Height);
            return area;
        }

        public double LateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * (this.Lenght * this.Height) + 2 * (this.Width * this.Height);
            return lateralSurfaceArea;
        }
        public double Volume()
        {
            double volume = this.Width * this.Lenght * this.Height;
            return volume;
        }

    }
}
