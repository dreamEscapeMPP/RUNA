using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stroy;
using UnityEngine.SceneManagement;
using NextScene;

public class EndingStory : MonoBehaviour
{
    [Tooltip("광고가 이 시간(초) 안에 뜨지 않으면 광고 없이 메인으로 이동")]
    public float adTimeout = 4f;

    [Tooltip("대사가 끝난 뒤 표시할 홈 버튼 프리팹 (HomeBtnCanvas). 비워두면 Resources/HomeBtnCanvas 를 찾는다")]
    public GameObject homeButtonPrefab;

    // AdMob 콜백은 백그라운드 스레드에서 올 수 있으므로 플래그만 세우고 Update(메인 스레드)에서 씬을 바꾼다.
    volatile bool goMainRequested = false;
    bool movedToMain = false;
    GameObject homeButtonInstance;

    // Start is called before the first frame update
    void Start()
    {
        // 엔딩에 도달한 순간 클리어로 저장 → 홈 버튼/광고/타임아웃 어떤 경로로 메인에 가도 처음부터 시작
        PlayerPrefs.SetInt("saveStage", 0);
        PlayerPrefs.Save();
        StartCoroutine(Play());
    }

    void Update()
    {
        if (goMainRequested && !movedToMain)
        {
            movedToMain = true;
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
    }

    IEnumerator Play()
    {
        yield return StartCoroutine(Narration.instance.EndingChat("헉......", 2));
        yield return StartCoroutine(Narration.instance.EndingChat("뭐였지......", 2));
        yield return StartCoroutine(Narration.instance.EndingChat("다행이다... 꿈이여서", 2));
        yield return StartCoroutine(Narration.instance.EndingChat("그러고 보니 오랜만에 생각났네", 2));
        yield return StartCoroutine(Narration.instance.EndingChat("토끼인형....내 루나....", 2));
        yield return StartCoroutine(Narration.instance.EndingChat("잊어버려서 미안해....", 2));
        Narration.instance.All_Off();
        yield return new WaitForSeconds(2f);

        // 대사가 끝나면 홈 버튼을 보여준다. 광고가 안 떠도 사용자가 직접 메인으로 갈 수 있다.
        ShowHomeButton();

        // 광고 호출. 광고가 닫히면 Main 으로 이동한다.
        // 광고 로드/표시에 실패하거나 adTimeout 안에 뜨지 않으면 광고 없이 Main 으로 이동한다.
        AdMobManager ads = AdMobManager.instance;
        if (ads == null)
        {
            GoMain();
            yield break;
        }

        ads.onHandleRewardedAdFailedToLoad = _ => GoMain();
        ads.onHandleRewardedAdFailedToShow = GoMain;
        ads.onHandleRewardedAdClosed = GoMain;

        bool initOk = true;
        try
        {
            ads.Init();
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("[EndingStory] AdMob Init 실패: " + e.Message);
            initOk = false;
        }

        if (!initOk)
        {
            GoMain();
            yield break;
        }

        ads.ShowAds(adTimeout, GoMain);
    }

    // 어느 스레드에서 불려도 안전. 실제 씬 전환은 Update 에서 한다.
    void GoMain()
    {
        goMainRequested = true;
    }

    void ShowHomeButton()
    {
        if (homeButtonInstance != null) return;
        GameObject prefab = homeButtonPrefab != null ? homeButtonPrefab : Resources.Load<GameObject>("HomeBtnCanvas");
        if (prefab == null)
        {
            Debug.LogWarning("[EndingStory] 홈 버튼 프리팹이 지정되지 않았습니다.");
            return;
        }
        homeButtonInstance = Instantiate(prefab);
    }
}
