using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InterfaceHandler : MonoBehaviour
{
    private readonly Dictionary<string, Action> InterfaceRealization = new Dictionary<string, Action>();

    [SerializeField]
    private ResultOutput _resultOutput = null;
    private CalculationData _calculator;
    private CalculationHandler _calculationHandler;

    private void Start()
    {
        InitializeDictionary();

        _calculator = FindObjectOfType<CalculationData>();
        _calculationHandler = GetComponent<CalculationHandler>();
    }

    private void InitializeDictionary()
    {
        InterfaceRealization.Add("clean", CleanScreen);
        InterfaceRealization.Add("sign", ChangeSign);
    }

    public void EnterInterface(string interfaceValue)
    {
        InputRealization(interfaceValue);
    }

    private void InputRealization(string value)
    {
        InterfaceRealization[value]();
    }

    private void CleanScreen()
    {
        _calculator.NumbersToZero();
        _calculator.NumberStringToZero();
        _calculationHandler.ChangeInput = false;
        _calculator.TextToDefault();
        _resultOutput.SetDefaultValues();
    }

    private void ChangeSign()
    {
        if (double.TryParse(_calculator.NumberString, out double number))
        {
            if (number != 0)
                number *= -1;
            _calculator.NumberString = number.ToString();

            if (_calculationHandler.ChangeInput)
                _resultOutput.UpdateFirstValueText(_calculator.NumberString);
            else
                _resultOutput.UpdateSecondValueText(_calculator.NumberString);
        }
    }
}
