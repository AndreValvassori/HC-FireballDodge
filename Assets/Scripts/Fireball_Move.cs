using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Move : MonoBehaviour
{
    public float Basevelocity;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Basevelocity = 1f + Random.Range(0.0f, 1.3f);
        rb = gameObject.GetComponent<Rigidbody>() as Rigidbody;

        float scale = Random.Range(0f, 0.5f);
        transform.localScale += new Vector3(scale, scale, 0);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 vel = rb.velocity;
        rb.velocity = new Vector3(vel.x, -Basevelocity, vel.z);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag != "fireball" && collision.transform.tag != "Wizard")
        {
            if (collision.transform.tag == "Player")
            {
                //Kills the player
            }
            else
                    if (collision.transform.tag == "Ground")
            {
                Destroy(gameObject);
            }
            else
                    if (collision.transform.tag == "fireball")
            {
                // Junta as fireballs!
            }
            else
            {
                //Destroy(gameObject);
            }
        }        
    }
}
