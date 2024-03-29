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
    private GameObject ChatText_bar; // ��ȭâ UI
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
        narration.UI_set(ChatText_bar);
        narration.Right_Image_set(right_img);
        narration.Left_Image_set(left_img); // ????? ????? ????
        narration.All_Off(); // ????? Off ???��? ????????
        narration.UI_On();
        yield return StartCoroutine(narration.Chat("????????", 2));
        narration.Right_Image_On();
        yield return StartCoroutine(narration.Chat("?????????", 2));
        narration.Right_Image_Off();
        narration.Left_Image_On();
        yield return StartCoroutine(narration.Chat("??????", 2));
    }
}
