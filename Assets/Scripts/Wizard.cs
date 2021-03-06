﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public string CurrentAction;
    public Animator anim;

    private Vector3 targetPosition;

    private int BaseTickUpdate = 10;
    public static int RangeUpdate = 100;
    public int TickUpdate;
    public int CurrentTick;

    private int frames;
    private int seconds;

    public GameObject cronometro;
    public GameObject Fireball_1;
    public GameObject Fireball_2;
    public GameObject Fireball_3;
    public GameObject Fireball_4;

    // Start is called before the first frame update
    void Start()
    {
        TickUpdate = BaseTickUpdate + 100 + Random.Range(1, 200);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentTick++;
        frames++;
        if(frames % 60 == 0)
        {
            seconds++;
            frames = 0;
            RangeUpdate--;

            if (seconds % 7 == 0)
            {
                Instantiate(cronometro, 
                    new Vector3(Random.Range(-2, 2), 6, 1), Quaternion.identity);
            }
        }
        



        if (CurrentTick >= TickUpdate)
        {
            CurrentTick = 0;
            TickUpdate = BaseTickUpdate + (RangeUpdate>0? Random.Range(1, RangeUpdate):0);

            if (CurrentAction == "")
            {
                switch (Random.Range(1, 4))
                {
                    case 1:
                        CurrentAction = "MoveLeft";
                        Move("Left");
                        break;
                    case 2:
                        CurrentAction = "MoveRight";
                        Move("Right");
                        break;
                    case 3:
                        CurrentAction = "Fire";
                        Fire(0);
                        break;
                        //case 4:
                        //    CurrentAction = "DoNothing";
                        //    break;
                };
            }
        }
    }

    public void Move(string type)
    {
        //anim.SetBool("Fire", false);
        if (type == "Left")
        {
            if(transform.position.x <= -2.0f)
            {
                Move("Right");
                CurrentAction = "";
            }
            else
            {
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                CurrentAction = "";
            }
        }
        else
        {
            if (transform.position.x >= 2.0f)
            {
                Move("Left");
            }
            else
            {
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                CurrentAction = "";
            }

        }
        if (Random.Range(1, 4) >= 2)
            Fire(Random.Range(1, 4));
    }

    public void Fire(int Random)
    {
        anim.Play("Wizard_Fire");
        CurrentAction = "";
        Debug.Log("Fire");

        Instantiate(Fireball_1, transform.position, Quaternion.identity);
        
    }

}
