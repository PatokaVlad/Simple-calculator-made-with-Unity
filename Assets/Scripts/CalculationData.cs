using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculationData : MonoBehaviour
{
    public string OperatorString { get; set; } = null;
    public string NumberString { get; set; } = null;
    public double SecondValue { get; set; }
    public double ResultValue { get; set; }
    public string StoredOperationType { get; set; } = null;
    public bool ResultOnScreen { get; set; } = false;
    public bool ResultValueIsNull { get; private set; } = true;
    public bool SecondValueIsNull { get; private set; } = true;

    public void NumbersToZero()
    {
        ResultValue = 0d;
        SecondValue = 0d;
        ResultValueIsNull = true;
        SecondValueIsNull = true;
    }

    public void NumberStringToZero()
    {
        NumberString = null;
    }

    public bool NumberStringNullCheck()
    {
        return NumberString == null;
    }

    public void ResultTextToZero()
    {
        NumberString = null;
        ResultOnScreen = false;
    }

    public void TextToDefault()
    {
        NumberString = null;
        OperatorString = null;
    }

    public void StoredOperationTypeToZero()
    {
        StoredOperationType = null;
    }

    public void ResultFromScreen()
    {
        if (ResultOnScreen)
        {
            ResultTextToZero();
        }
    }

    public bool CorrectInputCheck(string nextValue)
    {
        if (NumberStringNullCheck())
            return false;
        else if ("0" == NumberString)
            return nextValue == NumberString;
        else
            for (int i = 0; i < NumberString.Length; i++)
                if (NumberString[i] == ',')
                    return NumberString[i] == nextValue[0];
        return false;
    }

    public bool NumberStringLenghtCheck()
    {
        if (NumberStringNullCheck())
            return true;
        else
            return NumberString.Length < 15;
    }
}
