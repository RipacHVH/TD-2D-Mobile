using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatEnemy : MonoBehaviour
{
    Health healthScript;
    Waypoints WPscript;
    public GameObject Stage1;
    public GameObject Stage21;
    public GameObject Stage22;

    





    private void Start()
    {
        WPscript = gameObject.GetComponent<Waypoints>();
        healthScript = gameObject.GetComponent<Health>();
    }
    private void Update()
    {
        

        if (healthScript.Dublicate == 1f)
        {
            var S21 = Instantiate(Stage21, transform.position, transform.rotation);
            var S22 = Instantiate(Stage22, transform.position, transform.rotation);
            
            Waypoints S21W = S21.GetComponent<Waypoints>();
            S21W.waypointIndex = WPscript.waypointIndex;
            S21.transform.position = new Vector2(Stage1.transform.position.x, Stage1.transform.position.y);

            Waypoints S22W = S22.GetComponent<Waypoints>();
            S22W.waypointIndex = WPscript.waypointIndex;
            S22.transform.position = new Vector2(Stage1.transform.position.x, Stage1.transform.position.y);

            Destroy(Stage1);
            healthScript.Dublicate = 0f;
        }
        if (healthScript.Dublicate == 2.1f)
        {
            var S21 = Instantiate(Stage21, transform.position, transform.rotation);
            var S22 = Instantiate(Stage22, transform.position, transform.rotation);

            Waypoints S21W = S21.GetComponent<Waypoints>();
            S21W.waypointIndex = WPscript.waypointIndex;
            S21.transform.position = new Vector2(Stage1.transform.position.x, Stage1.transform.position.y);

            Waypoints S22W = S22.GetComponent<Waypoints>();
            S22W.waypointIndex = WPscript.waypointIndex;
            S22.transform.position = new Vector2(Stage1.transform.position.x, Stage1.transform.position.y);

            Destroy(Stage1);
            healthScript.Dublicate = 0f;
        }
        if (healthScript.Dublicate == 2.2f)
        {
            var S21 = Instantiate(Stage21, transform.position, transform.rotation);
            var S22 = Instantiate(Stage22, transform.position, transform.rotation);

            Waypoints S21W = S21.GetComponent<Waypoints>();
            S21W.waypointIndex = WPscript.waypointIndex;
            S21.transform.position = new Vector2(Stage1.transform.position.x, Stage1.transform.position.y);

            Waypoints S22W = S22.GetComponent<Waypoints>();
            S22W.waypointIndex = WPscript.waypointIndex;
            S22.transform.position = new Vector2(Stage1.transform.position.x, Stage1.transform.position.y);

            Destroy(Stage1);
            healthScript.Dublicate = 0f;
        }
    }
}
