using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public int collidingNumber = 0;
    public bool cancelButton = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("UnPlaceableSpace"))
        {
            collidingNumber++;
            //Debug.Log(collidingNumber);
        }
        if (collision.CompareTag("CancelButton"))
        {
            cancelButton = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("UnPlaceableSpace"))
        {
            collidingNumber--;
            //Debug.Log(collidingNumber);
        }
        if (collision.CompareTag("CancelButton"))
        {
            cancelButton = false;
        }
    }
}
