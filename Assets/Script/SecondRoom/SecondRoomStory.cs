using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Stroy;

public class SecondRoomStory : MonoBehaviour
{

    public GameObject backgroud_touch;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("saveStage", 2);
        StartCoroutine(Play());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(Narration.instance.Charater_Chat("여기는 어디일까? 토끼 인형이 엄청 많네....", 2));
        yield return StartCoroutine(Narration.instance.Chat("방을 둘러보자.", 2));
        backgroud_touch.GetComponent<TouchOnOff>().OnEnableColider2D();
    }

}
