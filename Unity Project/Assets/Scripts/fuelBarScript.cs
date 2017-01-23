
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuelBarScript : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;

    public float MaxFuelAmt { get; set; }
    public float NewFuelAmt
    {
        set
        {
            fillAmount = Map(value, MaxFuelAmt);
        }

    }

    [SerializeField]
    private Image content;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }
    private void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = fillAmount;
        }

    }

    private float Map(float value, float maxFuel)
    {

        return value / maxFuel;
    }

    // private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    //   {
    //float value, float inMin = 0, float inMax = 100, float outMin = 0, float outMax = 1)
    //value = current fuel value
    //inMin = lowest amount Fuel can go to (0)
    //inMax = Highest amount Fuel can go to 
    //outMin = 0 because  full fill is 1 and not filled is 0, so it's somewhere between there
    //outmax  = 1 
    //         return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    //  }
}