using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragMenuAnimations : MonoBehaviour
{
    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;
    public Image menu;
    public Image[] images;
    public GameObject Frames;
    Color turretAlpha;
    float fade;
    private void Start()
    {
        fade = menu.color.a;
        //turretAlpha = new Color(255, 255, 255, 0f);
    }
    public void OnEnableMenu()
    {
        fadeIn = true;
        fadeOut = false;
        //menu.color = new Color(255, 255, 255, 1f);
        for (int i = 0; i < 6; i++)
        {
            images[i].color = new Color(255, 255, 255, 1f);
            images[i].enabled = true;
        }
    }
    public void CloseMenu()
    {
        fadeOut = true;
        fadeIn = false;
                //menu.color = new Color(255, 255, 255, 0f);
        for (int i = 0; i < 6; i++)
        {
            images[i].color = new Color(255, 255, 255, 0f);
        }
    }
    bool closedByButton;
    public void CloseMenu2()
    {
        closedByButton = true;
        fadeOut = true;
        fadeIn = false;
        //menu.color = new Color(255, 255, 255, 0f);
        for (int i = 0; i < 6; i++)
        {
            images[i].enabled = false;
        }
    }
    private void Update()
    {
        if (fadeIn)
        {
            if (fade < 1)
            {
                Frames.SetActive(true);
                gameObject.GetComponent<Image>().enabled = true;
                menu.color = new Color(255, 255, 255, fade);
                fade += 2f * Time.deltaTime;
                if (fade >= 1)
                {

                    fadeIn = false;
                }
            }
        }
        if (fadeOut)
        {
            if (fade >= 0)
            {
                menu.color = new Color(255, 255, 255, fade);
                fade -= 2f * Time.deltaTime;
                if (fade <= 0)
                {
                    if (closedByButton)
                    {
                        Frames.SetActive(false);
                        gameObject.GetComponent<Image>().enabled = false;
                        closedByButton = false;
                    }
                    fadeOut = false;
                }
            }
        }
    }
}
