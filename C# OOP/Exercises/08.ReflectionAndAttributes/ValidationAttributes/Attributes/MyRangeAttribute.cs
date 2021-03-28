using System;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minvalue;
        private readonly int maxvalue;

        public MyRangeAttribute(int minvalue, int maxvalue, bool inclusive = true)
        {
            this.minvalue  = minvalue - Convert.ToInt32(inclusive);
            this.maxvalue  = maxvalue + Convert.ToInt32(inclusive);
        }

        public override bool IsValid(object obj)
        {
            int value = (int)obj;
            return value > minvalue && value < maxvalue;
        }
    }
}
