using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text lblPontuacao;
    public Text lblTempo;
    // Start is called before the first frame update
    void Start()
    {
        lblPontuacao.text = MainData.pontuacao.ToString();
        lblTempo.text = MainData.tempo.ToString();
    }

}
