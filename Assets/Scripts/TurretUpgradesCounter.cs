using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurretUpgradesCounter : MonoBehaviour
{
    public TextMeshProUGUI starsText;



    private void Start()
    {
        StartCoroutine(Stars());
    }


    IEnumerator Stars()
    {
        starsText.text = PlayerStats.Stars.ToString();

        yield return new WaitForSeconds(0);
        starsText.text = PlayerStats.Stars.ToString();

    }
}
