using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
namespace Gley.MobileAds.Internal
{
    public class MobileAdsTest_DD : MonoBehaviour
    {
        public static MobileAdsTest_DD Instance { set; get; }
        
        void Awake()
        {
            API.Initialize();
            DontDestroyOnLoad(this);
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
           
#if UNITY_IOS
            if (selectedAdvertiser != SupportedAdvertisers.Admob)
            {
                consentWindowButton.gameObject.SetActive(false);
            }
#endif

        }

        void Start()
        {
           
        }

        /// <summary>
        /// Show banner assigned from inspector
        /// </summary>
        public void ShawBanner()
        {
            API.ShowBanner(BannerPosition.Top, BannerType.Banner);
        }


        /// <summary>
        /// Hide banner assigned from inspector
        /// </summary>
        public void HideBanner()
        {
            API.HideBanner();
        }


        /// <summary>
        /// Show a medium rectangle ad, assigned from inspector
        /// </summary>
        public void ShowMRec()
        {
            API.ShowMRec(BannerPosition.Top);
        }


        /// <summary>
        /// Hide medium rectangle ad
        /// </summary>
        public void HideMRec()
        {
            API.HideMRec();
        }

        /// <summary>
        /// Show Interstitial assigned from inspector
        /// </summary>
        public void ShowInterstitial()
        {
            API.ShowInterstitial();
        }

        /// <summary>
        /// Show Open App ad assigned from inspector
        /// </summary>
        public void ShowAppOpen()
        {
            API.ShowAppOpen();
        }

        /// <summary>
        /// Show rewarded video assigned from inspector
        /// </summary>
        public void ShowRewardedVideo()
        {
            API.ShowRewardedVideo(CompleteMethod);
        }

        /// <summary>
        /// Show rewarded interstitial assigned from inspector
        /// </summary>
        public void ShowRewardedInterstitial()
        {
            API.ShowRewardedInterstitial(CompleteMethod);
        }

        /// <summary>
        /// Callback called when a rewarded video or interstitial is complete
        /// </summary>
        /// <param name="completed"></param>
        private void CompleteMethod(bool completed)
        {
            if (completed)
            {
                
            }
        }

        /// <summary>
        /// Open debug window
        /// </summary>
        public void OpenDebugWindow()
        {
            API.OpenDebugWindow();
        }

        /// <summary>
        /// Open consent popup
        /// </summary>
        public void OpenConsentWindow()
        {
            API.ShowBuiltInConsentPopup(ConsentPopupClosed);
        }


        /// <summary>
        /// Callback called when consent popup is closed
        /// </summary>
        private void ConsentPopupClosed()
        {
            GleyLogger.AddLog($"Consent Popup Closed");
        }

        /// <summary>
        /// This is for testing purpose
        /// </summary>
        void Update()
        {
           
        }


        /// <summary>
        /// View debug messages
        /// </summary>
        public void ShowLogsWindow()
        {
        }
        public void ShowInterstitialWithSystemCallback(Action<bool> callback)
        {
            UnityAction unityCallback = new UnityAction(() =>
            {
                bool completed = true;  // Assume ad completed, you can modify it as needed based on your ad logic.
                callback?.Invoke(completed);
            });

            API.ShowInterstitial(unityCallback);  // Call the ad with the correct UnityAction
        }



        // AppOpen example.
        private void OnApplicationPause(bool pause)
        {
            if (pause == false)
            {
                Gley.MobileAds.API.ShowAppOpen();
            }
        }
    }
}
