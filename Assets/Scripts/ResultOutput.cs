using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultOutput : MonoBehaviour
{
    [SerializeField]
    private Text firstNumberText = null;
    [SerializeField]
    private Text secondNumberText = null;
    [SerializeField]
    private Text operatorText = null;

    public readonly string defaultFirstNumberText = "___";
    public readonly string defaultSecondNumberText = "___";
    public readonly string defaultOperatorText = "_";

    public void UpdateValuesText(string firstNumberValue, string secondNumberValue)
    {
        firstNumberText.text = firstNumberValue;
        secondNumberText.text = secondNumberValue;
    }

    public void UpdateOperatorText(string operatorValue)
    {
        operatorText.text = operatorValue;
    }

    public void SetDefaultValues()
    {
        firstNumberText.text = defaultFirstNumberText;
        secondNumberText.text = defaultSecondNumberText;
        operatorText.text = defaultOperatorText;
    }

    public void UpdateSecondValueText(string secondNumberValue)
    {
        secondNumberText.text = secondNumberValue;
    }

    public void UpdateFirstValueText(string firstNumberValue)
    {
        firstNumberText.text = firstNumberValue;
    }

    public bool FirstNumberTextIsNull()
    {
        return firstNumberText.text == defaultFirstNumberText;
    }
}
