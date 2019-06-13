using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainData : MonoBehaviour
{
    public static int GameRunning = 1;

    public static int pontuacao = 0;
    public static int tempo = 0;
    public static int Shields = 0;
    public static int GuardianAngels = 0;

    public static int MaxScore = 0;

    private void Start()
    {
        MaxScore = PlayerPrefs.GetInt("MaxScore");
        
    }
}
