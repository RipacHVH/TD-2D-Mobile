using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Currency : MonoBehaviour
{
    public float money;
    public TextMeshProUGUI moneyText;
    public float minKillMoney;


    private void Start() {
        moneyText.text = money.ToString();

    }
    void Update()
    {
        money = Mathf.Round(money);
        moneyText.text = money.ToString();
    }
}
