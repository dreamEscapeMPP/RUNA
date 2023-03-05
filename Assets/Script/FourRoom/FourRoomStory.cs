using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stroy;

public class FourRoomStory : MonoBehaviour
{
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
        yield return StartCoroutine(Narration.instance.Charater_Chat("여기는 내 방인데.....", 2));
        yield return StartCoroutine(Narration.instance.Charater_Chat("엄마.... 아빠.....", 2));
        yield return StartCoroutine(Narration.instance.Charater_Chat("무서워 무서워 무서워 무서워", 2));
        yield return StartCoroutine(Narration.instance.Chat("방을 둘려보자.", 2));
    }
}
