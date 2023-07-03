using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    public float StartInvincibleTime;
    public float InvincibleDuration = 5f;
    public bool InvinclibleEnabled = false;
    public SpriteRenderer InvincibleBubble;

    private void Start()
    {
        StartInvincibleTime = Random.Range(2, 25);
    }
    private void Update()
    {
        StartInvincibleTime -= Time.deltaTime;

        if (StartInvincibleTime <=0f)
        {
            InvincibleDuration -= Time.deltaTime;

            if (InvincibleDuration >= 0f)
            {
                //Add invincible effect
                InvincibleBubble.enabled = true;
                InvinclibleEnabled = true;
            }
            else
            {
                //Remove invincible effect
                InvincibleBubble.enabled = false;
                InvinclibleEnabled = false;
            }

        }
    }
}
