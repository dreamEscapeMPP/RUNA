using GoogleMobileAds.Api;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Google Mobile Ads Unity 플러그인 v11 API 기준 (2026-09 업그레이드, 구 v7 RewardedAd API에서 이전)
public class AdMobManager : MonoBehaviour
{
    [Tooltip("체크하면 Google 공식 테스트 광고 ID 를 사용한다. 통합 검증용 — 출시 빌드에서는 반드시 꺼야 함")]
    public bool useTestAds = false;
    // Google 공식 리워드 테스트 ID (모든 앱에서 항상 테스트 광고가 나옴)
    const string TestRewardedAdUnitId = "ca-app-pub-3940256099942544/5224354917";

    private string adUnitId;
    private RewardedAd rewardedAd;

    public static AdMobManager instance;

    public System.Action<Reward> onHandleUserEarnedReward;
    public System.Action<LoadAdError> onHandleRewardedAdFailedToLoad;

    public System.Action onHandleRewardedAdFailedToShow;
    public System.Action onHandleRewardedAdClosed;

    private void Awake()
    {
        instance = this;
    }

    public void Init()
    {
        //adUnitId 설정
#if UNITY_EDITOR
        adUnitId = "unused";
#elif UNITY_ANDROID
        adUnitId = "ca-app-pub-4727835752295775/5917816098";
#elif UNITY_IPHONE
        adUnitId = "unexpected_platform";
#else
        adUnitId = "unexpected_platform";
#endif
        if (useTestAds) adUnitId = TestRewardedAdUnitId;

        // 광고 이벤트를 Unity 메인 스레드로 전달 (씬 전환 등을 콜백에서 바로 할 수 있게)
        MobileAds.RaiseAdEventsOnUnityMainThread = true;

        // 모바일 광고 SDK를 초기화하고 완료되면 광고를 로드함.
        MobileAds.Initialize(initStatus => { LoadRewardedAd(); });
    }

    private void LoadRewardedAd()
    {
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }

        RewardedAd.Load(adUnitId, new AdRequest(), (RewardedAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.Log("Rewarded ad failed to load: " + error);
                if (this.onHandleRewardedAdFailedToLoad != null) this.onHandleRewardedAdFailedToLoad(error);
                return;
            }

            Debug.Log("Rewarded ad loaded.");
            rewardedAd = ad;
            RegisterEventHandlers(ad);
        });
    }

    private void RegisterEventHandlers(RewardedAd ad)
    {
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad closed.");
            if (this.onHandleRewardedAdClosed != null) this.onHandleRewardedAdClosed();
            else loadMainRequested = true; // 별도 처리기가 없으면 기본 동작: 메인으로
        };
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.Log("Rewarded ad failed to show: " + error);
            if (this.onHandleRewardedAdFailedToShow != null) this.onHandleRewardedAdFailedToShow();
        };
    }

    // 이벤트는 메인 스레드로 오지만, 만약을 대비한 안전망
    private volatile bool loadMainRequested = false;

    private void Update()
    {
        if (loadMainRequested)
        {
            loadMainRequested = false;
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
    }

    public bool IsLoaded()
    {
        return rewardedAd != null && rewardedAd.CanShowAd();
    }

    public void ShowAds()
    {
        ShowAds(-1f, null);
    }

    /// <summary>
    /// 광고가 로드되면 표시한다. timeout(초) 안에 로드되지 않으면 onTimeout 을 호출한다 (timeout <= 0 이면 무제한 대기).
    /// </summary>
    public void ShowAds(float timeout, Action onTimeout)
    {
        StartCoroutine(this.ShowAdsRoutine(timeout, onTimeout));
    }

    private IEnumerator ShowAdsRoutine(float timeout, Action onTimeout)
    {
        float waited = 0f;
        while (true)
        {
            if (IsLoaded())
            {
                rewardedAd.Show((Reward reward) =>
                {
                    if (this.onHandleUserEarnedReward != null) this.onHandleUserEarnedReward(reward);
                });
                yield break;
            }

            waited += Time.deltaTime;
            if (timeout > 0f && waited >= timeout)
            {
                Debug.Log("reward ad not loaded within " + timeout + "s, skipping.");
                if (onTimeout != null) onTimeout();
                yield break;
            }

            yield return null;
        }
    }

    private void OnDestroy()
    {
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }
    }
}
