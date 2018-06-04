using System;

namespace M6_Attributes
{
    /// <summary>
    /// On the perfect size for a pizza
    ///    Eugenia Cheng
    /// School of Mathematics and Statistics, University of Sheffield
    /// https://c-6rtwjumjzx7877x24hmjslx2ex78yfkkx2ex78mjkx2efhx2ezp.g00.cnet.com/g00/3_c-6bbb.hsjy.htr_/c-6RTWJUMJZX77x24myyux3ax2fx2fhmjsl.x78yfkk.x78mjk.fh.zpx2frnx78hx2fhmjsl-uneef.uik_$/$/$?i10c.ua=1&i10c.dv=14 
    /// </summary>
    [Flag(FlagValue.Static)]
    public class PizzaFactory
    {
        const int alpha = 38; //scaling constant for the edge

        protected Pizza Prepere(Pizza a)
        {
            a.Radius = 36;
            a.VolumeBase = 1;
            a.VolumeTopping = 1;
            a.Temperature = 20;
            return a;
        }

        protected Pizza Bake(Pizza a)
        {
            a.Temperature = 200;
            return a;
        }

        public Pizza GetPizza()
        {
            Pizza a = new Pizza();
            a = Prepere(a);
            a = Bake(a);

            return a;
        }

        public static double GetVolumeIdealPizza(double radius, double thickness)
        {
            return Math.PI * radius * radius * thickness;
        }

        public static double GetAreaPizzaBase(double radius)
        {
            return Math.PI * radius;
        }

        public static double GetThicknessPizzaBase(double volumeBase, double radius)
        {
            return volumeBase / GetAreaPizzaBase(radius);
        }

        public static double GetWidthEdge(double radius)
        {
            
            return alpha / (radius * radius);
        }

        public static double GetAreaTopping(double radius)
        {
            return Math.PI * Math.Pow(radius- GetWidthEdge(radius), 2);
        }

        public static double GetThicknessTopping(double volumeTopping, double radius)
        {
            return volumeTopping / GetAreaTopping(radius);
        }

        public static double GetRatioToppingToBaseMiddle(double volumeBase, double volumeTopping, double radius)
        {
            return GetThicknessTopping(volumeTopping, radius) / GetThicknessPizzaBase(volumeBase, radius);
        }
    }

    public class Pizza
    {
        public double Radius { get; set; }
        public double VolumeBase { get; set; }
        public double VolumeTopping { get; set; }
        public int Temperature{
            get { return this.Temperature; }
            set
            {
                if (value > -273 && value< 200) this.Temperature = value;
            }
        }

        public void Cooling(int timeMinute)
        {
            if ((timeMinute * timeMinute) > this.Temperature)
                this.Temperature = 20;
            else
                this.Temperature = this.Temperature - (timeMinute * timeMinute);
        }
    }

}
