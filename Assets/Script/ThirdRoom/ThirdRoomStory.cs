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
        PlayerPrefs.SetInt("saveStage", 3);
        StartCoroutine(Play());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(Narration.instance.Charater_Chat("����� ����? ����....?", 2));
        yield return StartCoroutine(Narration.instance.Charater_Chat("������.... �Ӹ� ����", 2));
        yield return StartCoroutine(Narration.instance.Chat("���� �ѷ�����.", 2));
        backgroud_touch.GetComponent<TouchOnOff>().OnEnableColider2D();
    }
}
