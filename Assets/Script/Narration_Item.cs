using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stroy;

public class Narration_Item : MonoBehaviour
{
    public GameObject backgroud_DontTouch;
    GameObject backGround;
    public string narration;
    public bool isCharaterNarration = false;
    public bool OnceNarrationTime = false;

    void OnMouseDown()
    {
        if (isCharaterNarration)
        {
            //StartCoroutine(Narration.instance.Charater_Chat(narration, 2));
            StartCoroutine(Charater_Chat_NoneClick());
        }
        else
        {
            //StartCoroutine(Narration.instance.Chat(narration, 2));
            StartCoroutine(Chat_NoneClick());
        }
        if (OnceNarrationTime)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            OnceNarrationTime = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        backGround = GameObject.Find("background");
        if (backgroud_DontTouch == null)
        {
            backgroud_DontTouch = gameObject.transform.parent.gameObject;
        }
    }

    IEnumerator Charater_Chat_NoneClick()
    {
        backGround.GetComponent<TouchOnOff>().OffEnableColider2D(backgroud_DontTouch);
        yield return
            StartCoroutine(Narration.instance.Charater_Chat(narration, 2));
        //yield return new WaitForSeconds(3.0f);
        backGround.GetComponent<TouchOnOff>().OnEnableColider2D(backgroud_DontTouch);
    }

    IEnumerator Chat_NoneClick()
    {
        backGround.GetComponent<TouchOnOff>().OffEnableColider2D(backgroud_DontTouch);
        yield return
            StartCoroutine(Narration.instance.Chat(narration, 2));
        //yield return new WaitForSeconds(3.0f);
        backGround.GetComponent<TouchOnOff>().OnEnableColider2D(backgroud_DontTouch);
    }
}
