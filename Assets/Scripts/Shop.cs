using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    //Buying
    public bool nTurret;
    public bool fTurret;
    public bool hTurret;
    public bool sTurret;
    public bool tTurret;
    public bool lTurret;

    public float price;
    public Currency currencyScript;
    private void Start()
    {
        currencyScript = GameObject.Find("Currency").GetComponent<Currency>();


        if (nTurret)
        {
            price = 250;
        }
        if (fTurret)
        {
            price = 450;
        }
        if (hTurret)
        {
            price = 850;
        }
        if (sTurret)
        {
            price = 600;
        }
        if (tTurret)
        {
            price = 550;
        }
        if (lTurret)
        {
            price = 700;
        }
    }
    private RectTransform rectTransform;
    //DragnDrop dragScript;
    private void Update()
    {
        //if the money is enough for every turret it works fine
        //if the money isn't enough for every turret it doesn't work
        if (currencyScript.money >= price)
        {
            DragnDrop dragScript = gameObject.GetComponent<DragnDrop>();
            dragScript.enabled = true;
            //Debug.Log("enable");
        }
        if (currencyScript.money < price)
        {
            //Debug.Log("disable");
            DragnDrop dragScript = gameObject.GetComponent<DragnDrop>();
            dragScript.BackToStart();
            /*rectTransform = GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0f, 0f);*/
            
            dragScript.enabled = false;
        }
    }
}
