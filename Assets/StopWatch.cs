using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    public AudioClip EvilLaugh;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>() as Rigidbody;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = rb.velocity;
        rb.velocity = new Vector3(vel.x, -2, vel.z);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag != "fireball" && collision.transform.tag != "Wizard")
        {
            Destroy(gameObject);     
        }
        if (collision.transform.tag == "Wizard")
        {
            AudioSource.PlayClipAtPoint(EvilLaugh, this.gameObject.transform.position);
            Destroy(gameObject);
        }
    }
}
