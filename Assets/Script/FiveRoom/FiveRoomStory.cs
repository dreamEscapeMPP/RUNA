using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stroy;
using NextScene;

public class FiveRoomStory : MonoBehaviour
{
    public GameObject[] alphabet = new GameObject[4];
    public GameObject big_door_open_img;

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
        yield return StartCoroutine(Narration.instance.Charater_Chat("여기는 밝은 방이네", 2));
        yield return StartCoroutine(Narration.instance.Charater_Chat("아까는 너무 무서웠어....", 2));
        yield return StartCoroutine(Narration.instance.Charater_Chat("빨리 꿈에서 깨고 싶어....", 2));
        yield return StartCoroutine(Narration.instance.Chat("방을 둘려보자.", 2));
    }

    public void CheckFinish()
    {
        if(alphabet[0].GetComponent<AlphabetChange>().alphabet_num == 0 &&
            alphabet[1].GetComponent<AlphabetChange>().alphabet_num == 2 &&
            alphabet[2].GetComponent<AlphabetChange>().alphabet_num == 0 &&
            alphabet[3].GetComponent<AlphabetChange>().alphabet_num == 1)
        {
            big_door_open_img.SetActive(true);
            //GameObject.Find("door_open").GetComponent<BoxCollider2D>().enabled = true;
            //GameObject.Find("door_open").GetComponent<ClearNNext>().Change_backgournd_Sprite();
        }
    }
}
