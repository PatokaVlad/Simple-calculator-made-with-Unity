using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculationHandler : MonoBehaviour
{
    private readonly Dictionary<string, Func<double, double, double>> OperationRealization = new Dictionary<string, Func<double, double, double>>()
    {
        ["+"] = CalculationFunctions.Plus,
        ["-"] = CalculationFunctions.Minus,
        ["*"] = CalculationFunctions.Multiply,
        ["/"] = CalculationFunctions.Divide
    };

    [SerializeField]
    private ResultOutput _resultOutput = null;
    private CalculationData _calculator;
    private NumbersHandler _numbersHandler;

    public bool StartOperation { get; set; } = false;
    public bool ChangeInput { get; set; } = false;

    private void Start()
    {
        _calculator = FindObjectOfType<CalculationData>();
        _numbersHandler = GetComponent<NumbersHandler>();
    }

    public void EnterOperation(string operationValue)
    {
        OperationHandling(operationValue);
    }

    private void OperationHandling(string operationType)
    {
        _calculator.OperatorString = operationType;
        ChangeInputValue();

        if (StartOperation)
        {
            _calculator.ResultValue = OperationRealization[_calculator.StoredOperationType](_calculator.ResultValue, _calculator.SecondValue);
            ShowResult();
            _calculator.NumbersToZero();
            StartOperation = false;
        }

        EqualOperation(operationType);


        _resultOutput.UpdateOperatorText(_calculator.OperatorString);
    }

    private void EqualOperation(string operationType)
    {
        if (!EgualCheck(operationType))
        {
            _calculator.StoredOperationType = operationType;
        }
        else
        {
            _calculator.StoredOperationTypeToZero();

            _resultOutput.UpdateOperatorText(operationType);

            _resultOutput.UpdateSecondValueText(_resultOutput.defaultSecondNumberText);
            _resultOutput.UpdateFirstValueText(_calculator.NumberString);

            StartOperation = false;
            ChangeInput = false;
            _calculator.NumbersToZero();
        }
    }

    private void ShowResult()
    {
        _calculator.NumberString = _calculator.ResultValue.ToString();
        _calculator.ResultOnScreen = true;
    }

    private void ChangeInputValue()
    {
        if(!_calculator.NumberStringNullCheck())
        {
            ChangeInput = !ChangeInput;
            StartOperation = _numbersHandler.ChangeNumberRecord(ChangeInput);
        }
    }

    private bool EgualCheck(string operationValue)
    {
        return operationValue == "=";
    }
}
