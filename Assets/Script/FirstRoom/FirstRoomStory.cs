using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stroy;

public class FirstRoomStory : MonoBehaviour
{
    public GameObject backgroud_touch;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("saveStage", 1);
        StartCoroutine(Play());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(Narration.instance.Charater_Chat("어?", 2));
        yield return StartCoroutine(Narration.instance.Charater_Chat("뭐지 여기는 어디지?", 2));
        yield return StartCoroutine(Narration.instance.Charater_Chat("나 뭐하고 있었더라....", 2));
        yield return StartCoroutine(Narration.instance.Chat("방을 둘러보자.", 2));
        backgroud_touch.GetComponent<TouchOnOff>().OnEnableColider2D();
    }
}
