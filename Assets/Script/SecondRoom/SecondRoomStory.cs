using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Stroy;

public class SecondRoomStory : MonoBehaviour
{
    public Narration narration;

    // Start is called before the first frame update
    void Start()
    {
        narration = gameObject.AddComponent<Narration>();
        StartCoroutine(Play());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(narration.Charater_Chat("여기는 어디일까? 토끼 인형이 엄청 많네....", 2));
        yield return StartCoroutine(narration.Chat("방을 둘려보자.", 2));
    }

}
