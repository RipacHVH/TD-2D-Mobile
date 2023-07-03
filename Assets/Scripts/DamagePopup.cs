using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    public static DamagePopup Create(Vector3 position, string damageAmount)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, new Vector3 (position.x, position.y - 0.5f, position.z), Quaternion.identity);
        
        //float.TryParse(miss, out damageAmount);

        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount);
        
        return damagePopup;
    }

    private static int sortingOrder;

    private const float DISAPPEAR_TIMER_MAX = 0.5f;


    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;//(making the text curve)


    private void Awake()
    {
        textMesh = transform.GetComponent < TextMeshPro> ();
    }
    public void Setup(string damageAmount)
    {
        textMesh.SetText(damageAmount);
        textColor = textMesh.color;
        disappearTimer = DISAPPEAR_TIMER_MAX;
        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;
        moveVector = new Vector3(1, 1) * 3f; //(making the text curve)
    }
    private void Update()
    {
        transform.position += moveVector * Time.deltaTime;//(making the text curve)
        moveVector -= moveVector * 4f * Time.deltaTime;//(making the text curve)
        //float moveYSpeed = 2f;
        //transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        if (disappearTimer > DISAPPEAR_TIMER_MAX * 1f) {
            // First half of the popup lifetime
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount* Time.deltaTime;
        } else
        {
            // Second half of the popup lifetime
            float decreaseScaleAmount = 0.3f;
            transform.localScale -= Vector3.one * decreaseScaleAmount* Time.deltaTime;
        }


        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            // Start disappearing
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
