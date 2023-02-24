using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Item : MonoBehaviour
    {
        public bool isGetItem = false;
        private GameObject getItem; // 가져온 아이템 
        private GameObject getItem_small; // 가져온 작은 아이템 

        public void Get_Item(GameObject item)
        {
            if (item.tag == "Item" || item.tag == "Items") // 가져올 수 있는 아이템 태그
            {
                if (isGetItem == false)
                {
                    item.GetComponent<AudioSource>().Play();
                    isGetItem = true;
                    getItem = item;
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
                    }
                    else
                    {
                        getItem.SetActive(true);
                        if (getItem.tag == "Items")
                        {
                            getItem_small.SetActive(true);
                        }
                        isGetItem = false;
                    }
                }
            }
        }
    }
}