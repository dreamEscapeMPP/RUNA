using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    // �����
    // prefab Item_Canvas �� Hierarchy�� �ֱ�
    // ȹ���� �� �ִ� ���ǿ� Item �±� �ޱ�
    // ȹ���� �������� ���� �� �ִ� ��ġ�� ����� Ȱ��ȭ�� ���� �̹��� ���ӿ��� ���� ��Ȱ��ȭ
    // �� �����ۿ� ItemBox �±� �ް� �̸��� ȹ���� �̸� + "_answer"�̾����.
    // ex) rabbit1 <- ȹ���� ������ / rabbit1_answer <- ȹ���� �������� ���� ��ġ
    // ��ȣ�ۿ� �θ��� ����� SecondPlayer ���� (Input.GetMouseButtonDown(0))
    // �ش� Ŭ������ player���� �ٿ��� ����ϴ� ����� / �� scene �� �� ���� ����
    public class Item : MonoBehaviour
    {
        public bool isGetItem = false;
        private GameObject getItem; // ������ ������ 
        private GameObject getItem_small; // ������ ���� ������ 
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
            if (item.tag == "Item" || item.tag == "Items") // ������ �� �ִ� ������ �±�
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
            if (item.tag == "ItemBox") // ���ƾ��ϴ� ��� �±�
            {
                if (isGetItem == true)
                {
                    string item_answer = getItem.name + "_answer"; // ���ƾ��ϴ� ��� ���� �̸�
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