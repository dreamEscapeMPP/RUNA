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
        yield return StartCoroutine(Narration.instance.Charater_Chat("����� �� ���ε�.....", 2));
        yield return StartCoroutine(Narration.instance.Charater_Chat("����.... �ƺ�.....", 2));
        yield return StartCoroutine(Narration.instance.Charater_Chat("������ ������ ������ ������", 2));
        yield return StartCoroutine(Narration.instance.Chat("���� �ѷ�����.", 2));
    }
}