using System;

public class ExponentialNotation
{
    private float value;
    private int exponent;
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
    private void RecalculateExponents()
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
        return string.Format("{0} * 10^{1}", this.value, this.exponent);
    }

    public ExponentialNotation Squared()
    {
        return this.MultipliedBy(this);
    }

    public ExponentialNotation Add(ExponentialNotation value2)
    {
        if (this.exponent > value2.exponent)
        {
            while (this.exponent > value2.exponent)
            {
                value2.value /= 10;
                value2.exponent++;
            }
        }
        else
        {
            while (this.exponent < value2.exponent)
            {
                this.value /= 10;
                this.exponent++;
            }
        }

        return new ExponentialNotation
            (
                value: (this.value + value2.value),
                exponent: this.exponent,
                unit: this.MeasurementUnits
            );
    }

    public ExponentialNotation MultipliedBy(ExponentialNotation value2)
    {
        var temp = new ExponentialNotation
        (
            value: this.value * value2.value,
            exponent: this.exponent + value2.exponent,
            unit: this.MeasurementUnits
        );
        temp.RecalculateExponents();
        return temp;
    }

    public ExponentialNotation DivideBy(float numberToDivideBy)
    {
        return new ExponentialNotation
        (
            value: (this.value / numberToDivideBy),
            exponent: this.exponent,
            unit: this.MeasurementUnits
        );
    }

    public ExponentialNotation DividedBy(ExponentialNotation numberToDivideBy)
    {
        return new ExponentialNotation
        (
            value: (this.value / numberToDivideBy.value),
            exponent: this.exponent - numberToDivideBy.exponent,
            unit: this.MeasurementUnits
        );
    }
}
