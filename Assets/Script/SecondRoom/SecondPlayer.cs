using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Player;
using NextScene;

public class SecondPlayer : MonoBehaviour
{
    Item item; // 아이템할때만 필요

    // 두번째 방에서만 쓰는 것들
    public GameObject real_rabbit;
    public GameObject real_rabbit_small;
    public GameObject real_rabbit_answer;
    public GameObject memo;
    private int real_rabbit_check = 0;
    private int doort_check = 0;

    // Start is called before the first frame update
    void Start()
    {
        item = gameObject.AddComponent<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        // 이 아래 부분 똑같이 갖다가 쓰면 됨.
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.collider != null)
            {
                GameObject click_obj = hit.transform.gameObject;
                if (item.isGetItem == false)
                {
                    item.Get_Item(click_obj);
                }
                else
                {
                    item.Push_Item(click_obj);
                }
            }

            // 두번째 방에서만 쓰는 것들
            if (GameObject.Find("parts2_Rbook_5_answer").GetComponent<SpriteRenderer>().enabled == true &&
            GameObject.Find("parts1_leftbook_8_answer").GetComponent<SpriteRenderer>().enabled == true &&
            GameObject.Find("parts1_leftbook_9_answer").GetComponent<SpriteRenderer>().enabled == true &&
            GameObject.Find("parts2_Rbook_0_answer").GetComponent<SpriteRenderer>().enabled == true)
            {
                if (real_rabbit_check == 0)
                {
                    real_rabbit.SetActive(true);
                    real_rabbit_check = 1;
                    memo.SetActive(false);
                    real_rabbit_answer.SetActive(true);
                }
            }

            if (real_rabbit_check == 1 && GameObject.Find("real_rabbit_answer").GetComponent<SpriteRenderer>().enabled == true)
            {
                if (doort_check == 0)
                {
                    real_rabbit_small.SetActive(true);
                    GameObject.Find("door").GetComponent<ClearNNext>().Change_backgournd_Sprite();
                    doort_check = 1;
                }
            }
        }
    }
}
