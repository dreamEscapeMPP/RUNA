using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ItemNewCsNamespace
{
    public class ThirdRoomItem : MonoBehaviour
    {

        public static bool isGetItem = false;
        public static GameObject getItem; // 가져온 아이템 

        private GameObject ItemBox_UI_img;
        private GameObject Item_true_bgm;
        private GameObject Item_false_bgm;


        void Start()
        {
            ItemBox_UI_img = GameObject.Find("ItemBox_UI_img");
            Item_true_bgm = GameObject.Find("Item_true_bgm");
            Item_false_bgm = GameObject.Find("Item_false_bgm");
        }

        void OnMouseDown()
        {
            if (gameObject.tag == "Item")
                Get_Item(gameObject);
            if (gameObject.tag == "ItemBox")
            { // 놓아야하는 장소 태그
                Push_Item(gameObject);
            }
        }
        public void Get_Item(GameObject item)
        {
            if (isGetItem == false)
            {
                isGetItem = true;
                getItem = item;
                ItemBox_UI_img.GetComponent<Image>().sprite = getItem.GetComponent<SpriteRenderer>().sprite;
                ItemBox_UI_img.SetActive(true);
                getItem.GetComponent<SpriteRenderer>().enabled = false;
                getItem.GetComponent<BoxCollider2D>().enabled = false;

            }
        }

        public void Push_Item(GameObject item)
        {
            if (item.tag == "ItemBox") // 놓아야하는 장소 태그
            {
                if (isGetItem == true)
                {
                    string item_answer = getItem.name + "_check"; // 놓아야하는 장소 정답 이름
                    if (item.name == item_answer)
                    {
                        TableAnswer.answerCount++;
                    }
                    item.GetComponent<SpriteRenderer>().sprite = getItem.GetComponent<SpriteRenderer>().sprite;
                    TableAnswer.placementCardCount++;

                    if (TableAnswer.placementCardCount == 4)
                    {
                        TableAnswer.placementCardCount = 0;
                        if (TableAnswer.answerCount == 4)
                        {

                            TableAnswer.OpenDoor();
                            Item_true_bgm.GetComponent<AudioSource>().Play();
                        }
                        else
                        {
                            TableAnswer.answerCount = 0;

                            Item_false_bgm.GetComponent<AudioSource>().Play();
                            for (int i = 0; i < 4; i++)
                            {
                                GameObject.Find("card_show").transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
                                GameObject.Find("card_show").transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
                            }
                            for (int j = 0; j < 4; j++)
                            {
                                GameObject.Find("card_check").transform.GetChild(j).GetComponent<SpriteRenderer>().sprite = null;
                            }
                        }
                    }
                    isGetItem = false;
                    ItemBox_UI_img.SetActive(false);
                }
            }
        }
    }
}
