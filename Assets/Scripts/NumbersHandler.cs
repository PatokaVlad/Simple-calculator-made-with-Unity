using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersHandler : MonoBehaviour// операции над двумя числами, результат которых возвращает значение
{
    [SerializeField]
    private ResultOutput _resultOutput = null;
    private CalculationData _calculator;

    private bool changeOutString = false;

    private void Start()
    {
        _calculator = FindObjectOfType<CalculationData>();
    }

    public void EnterValue(string value)
    {
        NumberHandling(value);
    }

    private void NumberHandling(string numberValue)
    {
        _calculator.ResultFromScreen();

        if (!_resultOutput.FirstNumberTextIsNull())
            _resultOutput.SetDefaultValues();

        if (_calculator.NumberStringLenghtCheck())
        {                
            if(!_calculator.CorrectInputCheck(numberValue))
            {
                _calculator.NumberString += numberValue;

                if (changeOutString)
                {
                    _resultOutput.UpdateFirstValueText(_calculator.NumberString);
                }
                else
                {
                    _resultOutput.UpdateSecondValueText(_calculator.NumberString);
                }
            }
        }
    }

    public bool ChangeNumberRecord(bool changeValue)
    {
        bool startOperation = false;

        if (changeValue)
        {
            if(_calculator.ResultValueIsNull)
            {
                _calculator.ResultValue = double.Parse(_calculator.NumberString);
                changeOutString = true;
            }
        }
        else
        {
            if (_calculator.SecondValueIsNull)
            {
                _calculator.SecondValue = double.Parse(_calculator.NumberString);
                changeOutString = false;
                startOperation = true;
            }
        }

        _calculator.NumberStringToZero();
        return startOperation;
    }
}
