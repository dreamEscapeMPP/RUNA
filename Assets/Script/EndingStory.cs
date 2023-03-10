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
        yield return StartCoroutine(Narration.instance.EndingChat("��......", 2));
        yield return StartCoroutine(Narration.instance.EndingChat("������......", 2));
        yield return StartCoroutine(Narration.instance.EndingChat("�����̴�... ���̿���", 2));
        yield return StartCoroutine(Narration.instance.EndingChat("�׷��� ���� �������� ��������", 2));
        yield return StartCoroutine(Narration.instance.EndingChat("�䳢����....�� �糪....", 2));
        yield return StartCoroutine(Narration.instance.EndingChat("�ؾ������ �̾���....", 2));
        Narration.instance.All_Off();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
