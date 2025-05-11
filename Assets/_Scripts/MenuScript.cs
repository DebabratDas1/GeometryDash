using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Gley.MobileAds; // still needed for banner enums etc.
using UnityEngine.Events;

public class MenuScript : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject LevelPanel;
    public GameObject GamePlayPanel;
    public Slider MusicSlider, VfxSlider;

    private void Awake()
    {
        //Gley.MobileAds.Internal.MobileAdsTest.Instance.ShawBanner(); // Initialize and show if needed
        if (Configs.is_banner == 1)
        {
            //Gley.MobileAds.Internal.MobileAdsTest.Instance.HideBanner();
        }
        LevelPanel.SetActive(false);
        GamePlayPanel.SetActive(true);
    }

    private void Start()
    {
        if (Configs.is_banner == 1)
        {
            //Gley.MobileAds.Internal.MobileAdsTest.Instance.ShawBanner();
        }

        MusicSlider.value = PlayerPrefs.GetFloat("MusicSlider", .5f);
        VfxSlider.value = PlayerPrefs.GetFloat("VfxSlider", .5f);

        MusicSlider.onValueChanged.AddListener(delegate { musicSlideFunction(); });
        VfxSlider.onValueChanged.AddListener(delegate { vfxSlideFunction(); });
    }

    void musicSlideFunction()
    {
        PlayerPrefs.SetFloat("MusicSlider", MusicSlider.value);
    }

    void vfxSlideFunction()
    {
        PlayerPrefs.SetFloat("VfxSlider", VfxSlider.value);
    }

    public void StartBtn()
    {
        if (Configs.b_play == 1 && Configs.CheckTimeShowAds() && API.IsInterstitialAvailable())
        {
            Time.timeScale = 0f;

            // Show the interstitial ad using the existing method
            //Gley.MobileAds.Internal.MobileAdsTest.Instance.ShowInterstitial();

            // Proceed with the rest of the logic after showing the ad
            Time.timeScale = 1f;
            Configs.SetStartTime();
            int n = PlayerPrefs.GetInt("Numlevel", 1) % SceneManager.sceneCountInBuildSettings;
            if (n == 0) n = 1;
            SceneManager.LoadScene(4);
        }
        else
        {
            int n = PlayerPrefs.GetInt("Numlevel", 1) % SceneManager.sceneCountInBuildSettings;
            if (n == 0) n = 1;
            SceneManager.LoadScene(n);
        }
    }
    public void NewStartBtn()
    {
        LevelPanel.SetActive(true);
        GamePlayPanel.SetActive(false);
    }



    public void ShowSettings()
    {
        SettingPanel.SetActive(true);
    }

    public void HideSettings()
    {
        SettingPanel.SetActive(false);
    }
}
