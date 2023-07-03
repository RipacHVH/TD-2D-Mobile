using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lives : MonoBehaviour
{
    public float lives = 3f;
    public TextMeshProUGUI livesText;
    public Image BrokenHeart;
    public Image Heart;


    private void Start()
    {
        livesText.text = lives.ToString();


    }
    void Update()
    {

        livesText.text = lives.ToString();
    }
}
