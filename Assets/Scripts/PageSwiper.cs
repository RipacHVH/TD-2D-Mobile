using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageSwiper : MonoBehaviour {

    Vector3 ThirdPanel;
    Vector3 SecondPanel;
    Vector3 FirstPanel;
    Vector3 CurrentPos;
    RectTransform rt;
    [SerializeField]
    GameObject[] levels;

    private float desiredDuration = 1f;
    private float elapsedTime;
    bool Pthree;
    bool Ptwo;
    bool Pone;
    private void Start()
    {
        ThirdPanel = new Vector3(-1918f *2f, 0, 0);
        SecondPanel = new Vector3(-1918f, 0, 0);
        FirstPanel = new Vector3(0, 0, 0);
        CurrentPos = FirstPanel;
        rt = gameObject.GetComponent<RectTransform>();
        foreach (GameObject level in levels)
        {
            LeanTween.scale(level, new Vector3(1f, 1f, 1f), 1f).setEase(LeanTweenType.easeOutBounce);
        }

    }
    private void Update()
    {
        if (Pthree)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;
            CurrentPos = rt.localPosition;
            rt.localPosition = Vector2.Lerp(CurrentPos, ThirdPanel, Mathf.SmoothStep(0, 1, percentageComplete));

        }
        if (Ptwo)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;
            CurrentPos = rt.localPosition;
            rt.localPosition = Vector2.Lerp(CurrentPos, SecondPanel, Mathf.SmoothStep(0, 1, percentageComplete));

        }
        if (Pone)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;
            CurrentPos = rt.localPosition;
            rt.localPosition = Vector2.Lerp(CurrentPos, FirstPanel, Mathf.SmoothStep(0, 1, percentageComplete));
        }
    }
    public void Three()
    {
        elapsedTime = 0f;
        Pthree = true;
        Ptwo = false;
        Pone = false;
    }
    public void Two()
    {
        elapsedTime = 0f;
        Ptwo = true;
        Pone = false;
        Pthree = false;
    }

    public void One()
    {
        elapsedTime = 0f;
        Pone = true;
        Ptwo = false;
        Pthree = false;
    }

}
