namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        } 

        public override bool IsValid(object obj)
        {
            int input = (int)obj;

            if (input < minValue || input > maxValue)
            {
                return false;
            }

            return true;
        }
    }
}
