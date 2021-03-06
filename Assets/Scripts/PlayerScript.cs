﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // public variables
    public float BaseVelocity;
    public float BaseMultiplier;
    public AudioClip Stopwatch_Pickup;

    // private variables
    private int tickUpdate = 60;
    private int MaxPericia = 20;
    private bool inParede = false;
    private Animator anim;

    // public Stats variables
    public int CurrentPericia;

    // public components!
    public SpriteRenderer skin;
    public Rigidbody Player;
    public Button AttackButton;
    public Text ButtonText;
    public Text PericiaText;


    // Make this private!
    public float CurrentVelocity;
    public int currentTick = 0;
    //
    public string direcao = "direita";
    void Start()
    {
        Player = gameObject.GetComponent<Rigidbody>() as Rigidbody;
        skin = gameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
        anim = gameObject.GetComponent<Animator>() as Animator;

        Time.timeScale = 1;

        CurrentVelocity = BaseVelocity;

        MainData.tempo = 0;
        MainData.pontuacao = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTick += 1;

        // Check Player Touch
        if (Input.GetKey("d"))
        {
            direcao = "direita";
        }
        else
        if (Input.GetKey("a"))
        {
            direcao = "esquerda";
        }

        // Update Player Velocity.
        if (direcao == "direita")
        {
            Player.velocity = new Vector3(CurrentVelocity, Player.velocity.y, Player.velocity.z);
            skin.flipX = false;
        }
        else
        {
            Player.velocity = new Vector3(-CurrentVelocity, Player.velocity.y, Player.velocity.z);
            skin.flipX = true;
        }

        //
        if (CurrentPericia >= MaxPericia) AttackButton.interactable = true; else AttackButton.interactable = false;

        // Exec TickUpdate Routine.
        if (currentTick >= tickUpdate)
        {
            if (CurrentVelocity < 7.0f)
                CurrentVelocity = CurrentVelocity + (CurrentVelocity * BaseMultiplier);

            if (CurrentPericia < MaxPericia) CurrentPericia += 1;

            PericiaText.text = ($"Pericia: " + CurrentPericia.ToString());

            MainData.GameRunning = 0;

            MainData.tempo++;

            currentTick = 0;
        }


        anim.SetBool("InParede", inParede);
    }

    public void ButtonAttackClick()
    {
        CurrentPericia = 0;
    }
    public void ButtonMoveClick()
    {
        if (direcao == "esquerda")
            direcao = "direita";
        else
            direcao = "esquerda";
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.tag == "Parede")
            inParede = true;
        if (coll.transform.tag == "cronometro")
        {
            CurrentVelocity = CurrentVelocity - (CurrentVelocity * 0.20f);
            Wizard.RangeUpdate += 20;
        }
    }

    void OnCollisionExit(Collision coll)
    {
        if (coll.transform.tag == "Parede")
            inParede = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "cronometro")
        {
            CurrentVelocity = CurrentVelocity - (CurrentVelocity * 0.10f);
            Wizard.RangeUpdate += 10;
            AudioSource.PlayClipAtPoint(Stopwatch_Pickup, this.gameObject.transform.position);
        }
    }

}
