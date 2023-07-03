using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundVisuals : MonoBehaviour
{
    Vector2 Particles;
    public GameObject ParticlesPrefab;
    Rigidbody2D rigidbody2d;
    public bool instantiated = false;
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        instantiated = false;
    }
    private void Update()
    {
        Particles.x = gameObject.transform.position.x;
        rigidbody2d.velocity = new Vector2(0.3f, rigidbody2d.velocity.y);
        if (Particles.x >= 3.4f && !instantiated)
        {
            var Tashaci = Instantiate(ParticlesPrefab, new Vector2(-24.5f, -gameObject.transform.position.y), Quaternion.identity);
            Tashaci.transform.SetParent(gameObject.transform.parent, false);
            Tashaci.transform.localScale = gameObject.transform.localScale;
            //Tashaci.transform.position = gameObject.transform.position;

            instantiated = true;
        }
        if (Particles.x >= 25.29482f && instantiated)
        {
            Destroy(gameObject);
        }
    }

}
