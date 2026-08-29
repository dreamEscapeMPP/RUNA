using GoogleMobileAds.Api;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdMobManager : MonoBehaviour
{
    private string adUnitId;
    private RewardedAd rewardedAd;

    public static AdMobManager instance;

    public System.Action<Reward> onHandleUserEarnedReward;
    public System.Action<AdFailedToLoadEventArgs> onHandleRewardedAdFailedToLoad;

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
        string adUnitId = "unused";
#elif UNITY_ANDROID
        adUnitId = "ca-app-pub-4727835752295775/5917816098";
#elif UNITY_IPHONE
        string adUnitId = "key";
#else
        string adUnitId = "unexpected_platform";
#endif

        // 모바일 광고 SDK를 초기화함.
        MobileAds.Initialize(initStatus => { });

        //광고 로드 : RewardedAd 객체의 loadAd메서드에 AdRequest 인스턴스를 넣음
        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd = new RewardedAd(adUnitId);
        this.rewardedAd.LoadAd(request);


        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded; // 광고 로드가 완료되면 호출
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad; // 광고 로드가 실패했을 때 호출
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening; // 광고가 표시될 때 호출(기기 화면을 덮음)
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow; // 광고 표시가 실패했을 때 호출
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;// 광고를 시청한 후 보상을 받아야할 때 호출
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed; // 닫기 버튼을 누르거나 뒤로가기 버튼을 눌러 동영상 광고를 닫을 때 호출
    }
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("HandleRewardedAdLoaded");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("HandleRewardedAdFailedToLoad");
        if (this.onHandleRewardedAdFailedToLoad != null) this.onHandleRewardedAdFailedToLoad(args);

    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        Debug.Log("HandleRewardedAdOpening");
    }

    public void HandleRewardedAdFailedToShow(object sender, EventArgs args)
    {
        Debug.Log("HandleRewardedAdFailedToShow");
        if (this.onHandleRewardedAdFailedToShow != null) this.onHandleRewardedAdFailedToShow();
    }

    // 광고 콜백은 Android 에서 백그라운드 스레드로 들어오므로 씬 전환은 Update(메인 스레드)에서 한다.
    private volatile bool loadMainRequested = false;

    private void Update()
    {
        if (loadMainRequested)
        {
            loadMainRequested = false;
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        Debug.Log("HandleRewardedAdClosed");
        if (this.onHandleRewardedAdClosed != null) this.onHandleRewardedAdClosed();
        else loadMainRequested = true; // 별도 처리기가 없으면 기본 동작: 메인으로
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        Debug.Log("HandleUserEarnedReward");
        if (this.onHandleUserEarnedReward != null) this.onHandleUserEarnedReward(args);

    }

    public bool IsLoaded()
    {
        return this.rewardedAd.IsLoaded();
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
            if (this.rewardedAd != null && IsLoaded())
            {
                this.rewardedAd.Show();
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
}
