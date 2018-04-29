using System;

public class ExponentialNotation
{
    protected float value;
    protected int exponent;
    public SIUnit MeasurementUnits;

    public ExponentialNotation(float value, int exponent, SIUnit unit)
    {
        this.value = value;
        this.exponent = exponent;
        this.MeasurementUnits = unit;
        RecalculateExponents();
    }

    /// <summary>
    /// Ensure values are < 10 and > 0; with proper exponents
    /// </summary>
    protected void RecalculateExponents()
    {

        if (this.value / 10f > 1f)
        {
            //Number can be simplified
            //E.g. xx.xxx
            while (this.value / 10f > 1)
            {
                if (this.value / 10f < 1)
                    //Number can't be simplified any further
                    return;
                this.exponent += 1; //Increment the exponent tracker
                this.value /= 10f; // Decrease the size of the number
            }
        }
        else if (this.value / 10f < 0.1f)
        {
            //The number is now smaller than 0
            //E.g.   0.xxxxx
            while (this.value / 10f < 0.1f)
            {
                if (this.value / 10f > 1)
                    //The number has returned to proper notation, exit
                    return;
                this.exponent -= 1; //Decrement the exponent tracker
                this.value *= 10f; //Increase the size of the number
            }
        }
    }

    public float GetNormalizedValue()
    {
        this.RecalculateExponents();
        return this.value *= (float)Math.Pow(10, this.exponent);
    }

    public override string ToString()
    {
        this.RecalculateExponents();
        return string.Format("{0} * 10^{1} {2}", this.value, this.exponent, this.MeasurementUnits);
    }

    public static ExponentialNotation operator + (ExponentialNotation en1, ExponentialNotation en2)
    {
        if (en1.exponent > en2.exponent)
        {
            while (en1.exponent > en2.exponent)
            {
                en2.value /= 10;
                en2.exponent++;
            }
        }
        else
        {
            while (en1.exponent < en2.exponent)
            {
                en1.value /= 10;
                en1.exponent++;
            }
        }

        return new ExponentialNotation
            (
                value: (en1.value + en2.value),
                exponent: en1.exponent,
                unit: en1.MeasurementUnits
            );
    }

    public static ExponentialNotation operator * (ExponentialNotation exponentialValue1, ExponentialNotation exponentialValue2)
    {
        var temp = new ExponentialNotation
        (
            value: exponentialValue1.value * exponentialValue2.value,
            exponent: exponentialValue1.exponent + exponentialValue2.exponent,
            unit: exponentialValue1.MeasurementUnits
        );
        temp.RecalculateExponents();
        return temp;
    }

    public static ExponentialNotation operator / (ExponentialNotation exponentialValue, float floatValue)
    {
        var temp = new ExponentialNotation
        (
            value: exponentialValue.value / floatValue,
            exponent: exponentialValue.exponent,
            unit: exponentialValue.MeasurementUnits
        );
        temp.RecalculateExponents();
        return temp;
    }

    public static ExponentialNotation operator / (ExponentialNotation exponentialValue1, ExponentialNotation exponentialValue2)
    {
        var temp = new ExponentialNotation
        (
            value: (exponentialValue1.value / exponentialValue2.value),
            exponent: exponentialValue1.exponent - exponentialValue2.exponent,
            unit: exponentialValue1.MeasurementUnits
        );
        temp.RecalculateExponents();
        return temp;
    }
}
