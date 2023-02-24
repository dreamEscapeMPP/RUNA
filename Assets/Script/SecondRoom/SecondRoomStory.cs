using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Stroy;

public class SecondRoomStory : MonoBehaviour
{
    public GameObject text_bar;
    public Image right_img;
    public Image left_img;
    Narration narration;

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
        narration.UI_set(text_bar);
        narration.Right_Image_set(right_img);
        narration.Left_Image_set(left_img); // �̹��� ���ҽ� ����
        narration.All_Off(); // ó���� Off ���·� ������ֱ�
        narration.UI_On();
        narration.Right_Image_On();
        yield return StartCoroutine(narration.Chat("����� ����ϱ�?", 2));
        yield return StartCoroutine(narration.Chat("�䳢 ������ ��û ����....", 2));
        narration.Right_Image_Off();
        narration.UI_Off();
    }

}
