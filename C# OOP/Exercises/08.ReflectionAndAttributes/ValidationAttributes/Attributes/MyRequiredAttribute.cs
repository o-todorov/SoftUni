﻿namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            return !string.IsNullOrEmpty((string)obj);
        }
    }
}