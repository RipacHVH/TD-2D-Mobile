using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Canvas canvas = gameObject.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;
    }
}
