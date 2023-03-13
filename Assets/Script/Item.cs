using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    // 사용방법
    // prefab Item_Canvas 를 Hierarchy에 넣기
    // 획득할 수 있는 물건에 Item 태그 달기
    // 획득한 아이템을 놓을 수 있는 위치에 정답시 활성화할 정답 이미지 게임오젝 놓고 비활성화
    // 위 아이템에 ItemBox 태그 달고 이름이 획득한 이름 + "_answer"이어야함.
    // ex) rabbit1 <- 획득한 아이템 / rabbit1_answer <- 획득한 아이템을 놓을 위치
    // 상호작용 부르는 방법은 SecondPlayer 참고 (Input.GetMouseButtonDown(0))
    // 해당 클래스는 player에게 붙여서 사용하는 방식임 / 한 scene 에 한 개만 존재
    public class Item : MonoBehaviour
    {
        public bool isGetItem = false;
        private GameObject getItem; // 가져온 아이템 
        private GameObject getItem_small; // 가져온 작은 아이템 
        private GameObject ItemBox_UI_img;
        private GameObject Item_true_bgm;
        private GameObject Item_false_bgm;

        public static Item instance;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            ItemBox_UI_img = GameObject.Find("ItemBox_UI_img");
            Item_true_bgm = GameObject.Find("Item_true_bgm");
            Item_false_bgm = GameObject.Find("Item_false_bgm");
        }

        public void Get_Item(GameObject item)
        {
            if (item.tag == "Item" || item.tag == "Items") // 가져올 수 있는 아이템 태그
            {
                if (isGetItem == false)
                {
                    item.GetComponent<AudioSource>().Play();
                    isGetItem = true;
                    getItem = item;
                    ItemBox_UI_img.GetComponent<Image>().sprite = getItem.GetComponent<SpriteRenderer>().sprite;
                    ItemBox_UI_img.SetActive(true);
                    getItem.SetActive(false);
                    if(item.tag == "Items")
                    {
                        string item2 = item.name + " (1)";
                        getItem_small = GameObject.Find(item2);
                        getItem_small.SetActive(false);
                    }
                }
            }
        }

        public void Push_Item(GameObject item)
        {
            if (item.tag == "ItemBox") // 놓아야하는 장소 태그
            {
                if (isGetItem == true)
                {
                    string item_answer = getItem.name + "_answer"; // 놓아야하는 장소 정답 이름
                    if (item.name == item_answer)
                    {
                        item.GetComponent<SpriteRenderer>().enabled = true;
                        isGetItem = false;
                        Item_true_bgm.GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        Item_false_bgm.GetComponent<AudioSource>().Play();
                        getItem.SetActive(true);
                        if (getItem.tag == "Items")
                        {
                            getItem_small.SetActive(true);
                        }
                        isGetItem = false;
                    }
                    ItemBox_UI_img.SetActive(false);
                }
            }
        }
    }
}