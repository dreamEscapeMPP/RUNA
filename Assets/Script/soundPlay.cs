using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//각 객체에 AudioSource 컴포넌트 추가 후 원하는 사운드 Clip에 넣어두고,
//해당스크립트추가

public class soundPlay : MonoBehaviour
{
    public float waitSecObj = 2;
    public bool deleteCheck = false;
    private void OnMouseDown()
    {

        if (deleteCheck)
            StartCoroutine(Delete_Object());
        else
            Play_SoundSource();
    }

    private void Play_SoundSource()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
    //스크립트 넣지않고 함수에 해당 객체를 넣는 방법, (빈객체에 꼭 넣어줘야함)
    public void Play_SoundSource(GameObject obj_play_sound)
    {
        obj_play_sound.GetComponent<AudioSource>().Play();
    }

    //소리 들리고 객체 없애기 위해..
    public IEnumerator Delete_Object()
    {
        Play_SoundSource();
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        yield return new WaitForSeconds(waitSecObj);
    }
}

