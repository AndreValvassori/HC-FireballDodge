using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;


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
        string gameId = "3157578";
        bool testMode = true;


        MaxScore = PlayerPrefs.GetInt("MaxScore");
        if (Monetization.isSupported)
        {
            Monetization.Initialize(gameId, testMode);
        }
        Advertisement.Initialize(gameId,testMode);

        Advertisement.Banner.Hide(false);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady("GameBanner"))
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Banner.Show("GameBanner");
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

}
