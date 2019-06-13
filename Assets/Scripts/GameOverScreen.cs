using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text lblPontuacao;
    public Text lblTempo;
    public Text lblRecorde;
    // Start is called before the first frame update
    void Start()
    {

        if (MainData.pontuacao > MainData.MaxScore)
        {
            MainData.MaxScore = MainData.pontuacao;
            PlayerPrefs.SetInt("MaxScore", MainData.MaxScore);
        }


        lblPontuacao.text = MainData.pontuacao.ToString();
        lblTempo.text = MainData.tempo.ToString();
        lblRecorde.text = MainData.MaxScore.ToString();
    }

}
