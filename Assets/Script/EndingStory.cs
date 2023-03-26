using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stroy;
using UnityEngine.SceneManagement;
using NextScene;

public class EndingStory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("saveStage", 0);
        StartCoroutine(Play());
    }

    // Update is called once per frame
    void Update()
    {
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


        // SceneManager.LoadScene("Main", LoadSceneMode.Single);
        AdMobManager.instance.Init();
        AdMobManager.instance.ShowAds();
        //SceneManager.LoadScene("Main", LoadSceneMode.Single);
        //광고호출
        //   gameObject.GetComponent<AdmobScreenAd>().ShowAd();
    }
}
