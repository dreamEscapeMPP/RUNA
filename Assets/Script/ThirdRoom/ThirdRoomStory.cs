using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stroy;

public class ThirdRoomStory : MonoBehaviour
{
    public GameObject backgroud_touch;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Play());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(Narration.instance.Charater_Chat("여기는 어디야? 생일....?", 2));
        yield return StartCoroutine(Narration.instance.Charater_Chat("뭐였지.... 머리 아파", 2));
        yield return StartCoroutine(Narration.instance.Chat("방을 둘러보자.", 2));
        backgroud_touch.GetComponent<TouchOnOff>().OnEnableColider2D();
    }
}
