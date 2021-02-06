using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] 
    private string value;

    private CalculationHandler _calculationHandler;
    private InterfaceHandler _interfaceHandler;
    private NumbersHandler _numbersHandler;

    private void Start()
    {
        _calculationHandler = FindObjectOfType<CalculationHandler>();
        _interfaceHandler = FindObjectOfType<InterfaceHandler>();
        _numbersHandler = FindObjectOfType<NumbersHandler>();
    }

    public void OnCalculatorPressed()
    {
        _calculationHandler.EnterOperation(value);
    }

    public void OnInterfacePressed()
    {
        _interfaceHandler.EnterInterface(value);
    }

    public void OnNumberPressed()
    {
        _numbersHandler.EnterValue(value);
    }
}
