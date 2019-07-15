using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;

public class AdScript : MonoBehaviour, IUnityAdsListener
{

    string gameId = "3157578";
    string myPlacementId = "rewardedVideo";
    bool testMode = true;
    bool alreadydied = false;


    public GameObject panel;
    private Canvas pnlcanvas;

    // Initialize the Ads listener and service:
    void Start()
    {
        panel = GameObject.Find("canvasPanel");
        pnlcanvas = panel.GetComponent<Canvas>() as Canvas;

        if (Monetization.isSupported)
        {
            Monetization.Initialize(gameId, testMode);
        }
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }

    public void ShowRewardedVideo()
    {
        if(!alreadydied)
        {
            Advertisement.Show(myPlacementId);
            alreadydied = true;
        }
        else
        {
            GameOver();
        }

    }

    public void GameOver()
    {
        try { Handheld.Vibrate(); } catch { }
        SceneManager.LoadScene("GameOver");
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, UnityEngine.Advertisements.ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == UnityEngine.Advertisements.ShowResult.Finished)
        {
            pnlcanvas.enabled = false;
            Time.timeScale = 1;
            // Reward the user for watching the ad to completion.
        }
        else if (showResult == UnityEngine.Advertisements.ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == UnityEngine.Advertisements.ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        /*if (placementId == myPlacementId)
        {
            Advertisement.Show(myPlacementId);
        }*/
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
}