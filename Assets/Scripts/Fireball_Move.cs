﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fireball_Move : MonoBehaviour
{
    public float Basevelocity;

    public Rigidbody rb;

    public GameObject panel;
    private Canvas pnlcanvas;

    // Start is called before the first frame update
    void Start()
    {
        Basevelocity = 1f + Random.Range(0.0f, 1.3f);
        rb = gameObject.GetComponent<Rigidbody>() as Rigidbody;

        float scale = Random.Range(0f, 0.5f);
        transform.localScale += new Vector3(scale, scale, 0);

        panel = GameObject.Find("canvasPanel");
        pnlcanvas = panel.GetComponent<Canvas>() as Canvas;
        Debug.Log(panel.name);
    }

    // Update is called once per frame
    void Update()
    {
//        if (MainData.GameRunning == 0)
//            return;

        Vector3 vel = rb.velocity;
        rb.velocity = new Vector3(vel.x, -Basevelocity, vel.z);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag != "fireball" && collision.transform.tag != "Wizard")
        {
            if (collision.transform.tag == "Player")
            {
                if(MainData.Shields > 0)
                {
                    MainData.Shields--;
                }
                else if (MainData.GuardianAngels > 0)
                {

                }
                else
                {
                    pnlcanvas.enabled = true;
                    Time.timeScale = 0;
                }
            }
            else
            if (collision.transform.tag == "Ground")
            {
                Destroy(gameObject);
                MainData.pontuacao ++;
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
