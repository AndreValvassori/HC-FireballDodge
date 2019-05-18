using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public string CurrentAction;

    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentAction == "")
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

    public void Move(string type)
    {
        if(type == "Left")
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
    }

    public void Fire(int Random)
    {
        CurrentAction = "";
    }

}
