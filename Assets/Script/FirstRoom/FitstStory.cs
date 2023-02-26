using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Stroy;
//using WhileStroy;

public class FitstStory : MonoBehaviour
{
    public GameObject backgroud_touch;
    public GameObject ui;
    public Image right_img;
    //public Narration narration;
    //ShowUINarration showUINarration;
    // Start is called before the first frame update
    void Start()
    {
        //showUINarration = new ShowUINarration();
        //narration = new Narration();//gameObject.AddComponent<Narration>();
        StartCoroutine(Play());

    }


    IEnumerator Play()
    {
        yield return new WaitForSeconds(1f);
        // narration.UI_set(ui);
        //narration.Right_Image_set(right_img);
        //StartCoroutine(TypingSound());
        //yield return StartCoroutine(narration.Chat("어라 여기가 어디지", 1));
        //narration.Right_Image_Off();

        //showUINarration.OffCollider();

        backgroud_touch.GetComponent<TouchOnOff>().OnEnableColider2D();
    }

    IEnumerator TypingSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<AudioSource>().Pause();
    }




}
