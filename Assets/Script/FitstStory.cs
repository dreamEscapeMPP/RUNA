using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Stroy;

public class FitstStory : MonoBehaviour
{
    public GameObject backgroud_touch;
    public GameObject player_Chat_view;
    public GameObject ui;
    public Image right_img;
    Narration narration;
    // Start is called before the first frame update
    void Start()
    {
        narration = new Narration();//gameObject.AddComponent<Narration>();
        StartCoroutine(Play());

    }

    IEnumerator Play()
    {
        narration.UI_set(ui);
        narration.Right_Image_set(right_img);


        yield return StartCoroutine(narration.Chat("��� ���Ⱑ �����", 2));
        narration.Right_Image_Off();

        OffCollider();
    }

    //�߰� �� �Ⱥ��̰���
    public void OffCollider()
    {
        player_Chat_view.SetActive(false);
        backgroud_touch.GetComponent<TouchOnOff>().OnEnableColider2D();
    }
    public void OnCollider()
    {
        player_Chat_view.SetActive(true);
        backgroud_touch.GetComponent<TouchOnOff>().OffEnableColider2D();
    }


}
