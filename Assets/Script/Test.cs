using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Stroy;

public class Test : MonoBehaviour
{
    public Text ui;
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
        narration.UI_set(ui);
        narration.Right_Image_set(right_img);
        narration.Left_Image_set(left_img); // 이미지 리소스 지정
        narration.All_Off(); // 처음에 Off 상태로 만들어주기
        narration.UI_On();
        yield return StartCoroutine(narration.Chat("안녕하세요", 2));
        narration.Right_Image_On();
        yield return StartCoroutine(narration.Chat("누구세요?", 2));
        narration.Right_Image_Off();
        narration.Left_Image_On();
        yield return StartCoroutine(narration.Chat("넌데요?", 2));
    }
}
