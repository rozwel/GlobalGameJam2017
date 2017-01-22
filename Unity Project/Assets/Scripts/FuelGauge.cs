using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelGauge : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private float fillAmountBlack;

    public float MaxFuelAmt { get; set; }
    public float NewFuelAmt
    {
        set
        {
            fillAmount = Map(value, MaxFuelAmt);
            //fillAmount = Map(NewFuelAmt, MaxFuelAmt);
            fillAmountBlack = fillAmount + (float).1;
        }

    }
    [SerializeField]
    private Image Yellow;
    [SerializeField]
    private Image Black;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleGauge();
    }
    private void HandleGauge()
    {
       // if (fillAmount != Yellow.fillAmount)
      //  {
            Yellow.fillAmount = fillAmount;
            Black.fillAmount = fillAmountBlack;

      //  }

    }
    private float Map(float value, float maxFuel)
    {

        return value / maxFuel;
    }

}



