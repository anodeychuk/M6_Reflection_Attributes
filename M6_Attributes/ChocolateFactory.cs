namespace M6_Attributes
{
    [Flag(FlagValue.Public)]
    public class ChocolateFactory
    {
        public int Cocoa { get; set; }
        public int Sugar { get; set; }
        public int Butter { get; set; }
        public int Milk { get; set; }

        public int temperature;
        public int Temperature
        {
            get { return this.temperature; }
            set { if (value > -273 && value < (int)Heat.Boiling) temperature = value; }
        }

        public ChocolateFactory()
        {
            this.Cocoa = 0;
            this.Sugar = 0;
            this.Butter = 0;
            this.Milk = 0;
            this.Temperature = 20;
        }

        protected enum Heat
        {
            Solidify = 10, Heating = 80, Boiling = 108
        }

        public bool AddMainIngredient(int milk, int cocoa, int butter, int suger)
        {
            bool isAccurate = true;
            if (milk != 100 || cocoa != 20 || butter != 250 / 4 || suger != 10) isAccurate = false;

            this.Milk = milk;
            this.Cocoa = cocoa;
            this.Butter = butter;

            return isAccurate;
        }
        public void Heating()
        {
            this.Temperature = (int)Heat.Heating;
        }

        public void Booling()
        {
            this.Temperature = (int)Heat.Boiling;
        }

        public void Solidify()
        {
            this.Temperature = (int)Heat.Solidify;
        }

        public static double Cost(double weight)
        {
            double cost = 0.5;
            return cost * weight;
        }

        public static double HowManyCal(double weight)
        {
            double cal = 246;
            return cal * weight;
        }

    }
}
