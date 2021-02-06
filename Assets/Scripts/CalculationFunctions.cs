using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CalculationFunctions
{
    public static double Plus(double firstValue, double secondValue)
    {
        return firstValue + secondValue;
    }

    public static double Minus(double firstValue, double secondValue)
    {
        return firstValue - secondValue;
    }

    public static double Multiply(double firstValue, double secondValue)
    {
        return firstValue * secondValue;
    }

    public static double Divide(double firstValue, double secondValue)
    {
        if (secondValue != 0)
            return firstValue / secondValue;
        else
        {
            return 000;
        }
    }
}
