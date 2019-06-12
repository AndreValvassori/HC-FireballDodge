using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // public variables
    public float BaseVelocity;
    public float BaseMultiplier;

    // private variables
    private int tickUpdate = 60;
    private int MaxPericia = 20;

    // public Stats variables
    public int CurrentPericia;

    // public components!
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
        Player = gameObject.GetComponent < Rigidbody >() as Rigidbody;
        CurrentVelocity = BaseVelocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTick += 1;

        // Check Player Touch
        if (Input.GetKey("d"))
        {
            direcao = "direita";
        } else
        if (Input.GetKey("a"))
        {
            direcao = "esquerda";
        }

        // Update Player Velocity.
        if (direcao == "direita")
        {
            Player.velocity = new Vector3(CurrentVelocity, Player.velocity.y,Player.velocity.z);
        }
        else
        {
            Player.velocity = new Vector3(-CurrentVelocity, Player.velocity.y, Player.velocity.z);
        }

        //
        if (CurrentPericia >= MaxPericia) AttackButton.interactable = true; else AttackButton.interactable = false;

        // Exec TickUpdate Routine.
        if (currentTick >= tickUpdate)
        {
            if (CurrentVelocity < 7.0f)
                CurrentVelocity = CurrentVelocity + (CurrentVelocity * BaseMultiplier);

            if (CurrentPericia < MaxPericia) CurrentPericia += 1;

            PericiaText.text = ($"Pericia: " +  CurrentPericia.ToString());

            MainData.tempo++;

            currentTick = 0;
        }
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
        if(coll.transform.tag == "fireball")
        {            
        }
    }

}
