using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdScript : MonoBehaviour
{
    public GameObject panel;
    private Canvas pnlcanvas;

    public void Start()
    {
        panel = GameObject.Find("canvasPanel");
        pnlcanvas = panel.GetComponent<Canvas>() as Canvas;
        //panelGameOver = GameObject.Find("panelGameOver");
    }

    public void GameOver()
    {
        try { Handheld.Vibrate(); } catch { }
        SceneManager.LoadScene("GameOver");
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");



                pnlcanvas.enabled = false;
                Time.timeScale = 1;

                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}