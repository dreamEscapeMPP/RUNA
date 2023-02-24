using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Item : MonoBehaviour
    {
        public bool isGetItem = false;
        private GameObject getItem; // ������ ������ 
        private GameObject getItem_small; // ������ ���� ������ 

        public void Get_Item(GameObject item)
        {
            if (item.tag == "Item" || item.tag == "Items") // ������ �� �ִ� ������ �±�
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
            if (item.tag == "ItemBox") // ���ƾ��ϴ� ��� �±�
            {
                if (isGetItem == true)
                {
                    string item_answer = getItem.name + "_answer"; // ���ƾ��ϴ� ��� ���� �̸�
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