using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyToDestroy : MonoBehaviour
{
    Currency currencyScript;
    public float DestroyPrice = 500f;
    Button button;
    void Start()
    {
        currencyScript = GameObject.Find("Currency").GetComponent<Currency>();
        button = gameObject.GetComponent<Button>();
    }
    public void BTD()
    {
        if(currencyScript.money >= DestroyPrice)
        {
            currencyScript.money -= DestroyPrice;
            button.interactable = false;
            Destroy(gameObject, 0.5f);
        }
    }
}
