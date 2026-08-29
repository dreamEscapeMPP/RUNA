using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ItemNewCsNamespace
{
    // 카드(cardN_show, 태그 Item)를 집어서 정답칸(cardN_show_check, 태그 ItemBox)에 놓는다.
    // - 빈 칸에 놓기: 카드가 칸에 들어간다.
    // - 이미 카드가 있는 칸에 놓기: 들고 있던 카드와 칸의 카드를 맞바꾼다(칸의 카드가 손으로 옴).
    // - 빈손으로 카드가 있는 칸 클릭: 그 카드를 다시 집는다.
    // 4칸이 모두 차면 정답을 판정한다.
    public class ThirdRoomItem : MonoBehaviour
    {
        const int SlotCount = 4;

        public static bool isGetItem = false;
        public static GameObject getItem; // 가져온 아이템

        // 정답칸 -> 그 칸에 놓인 카드
        static readonly Dictionary<GameObject, GameObject> placed = new Dictionary<GameObject, GameObject>();

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

        // 카드를 손에 든다
        void HoldCard(GameObject card)
        {
            isGetItem = true;
            getItem = card;
            ItemBox_UI_img.GetComponent<Image>().sprite = card.GetComponent<SpriteRenderer>().sprite;
            ItemBox_UI_img.SetActive(true);
            card.GetComponent<SpriteRenderer>().enabled = false;
            card.GetComponent<BoxCollider2D>().enabled = false;
        }

        void ClearHand()
        {
            isGetItem = false;
            getItem = null;
            ItemBox_UI_img.SetActive(false);
        }

        // 칸에 카드를 놓는다 (표시 + 기록)
        static void SetSlot(GameObject slot, GameObject card)
        {
            slot.GetComponent<SpriteRenderer>().sprite = card != null ? card.GetComponent<SpriteRenderer>().sprite : null;
            if (card != null) placed[slot] = card;
            else placed.Remove(slot);
        }

        static GameObject CardInSlot(GameObject slot)
        {
            GameObject card;
            return placed.TryGetValue(slot, out card) ? card : null;
        }

        public void Get_Item(GameObject item)
        {
            if (isGetItem == false)
            {
                HoldCard(item);
            }
        }

        public void Push_Item(GameObject slot)
        {
            if (slot.tag != "ItemBox") return; // 놓아야하는 장소 태그

            GameObject existing = CardInSlot(slot);

            if (isGetItem == false)
            {
                // 빈손으로 카드가 있는 칸을 누르면 그 카드를 다시 집는다
                if (existing != null)
                {
                    SetSlot(slot, null);
                    HoldCard(existing);
                }
                return;
            }

            GameObject held = getItem;
            SetSlot(slot, held);

            if (existing != null)
            {
                // 교체: 원래 있던 카드가 손으로 온다
                HoldCard(existing);
            }
            else
            {
                ClearHand();
            }

            if (placed.Count == SlotCount)
                Evaluate();
        }

        void Evaluate()
        {
            int correct = 0;
            foreach (var pair in placed)
            {
                if (pair.Key.name == pair.Value.name + "_check") // 놓아야하는 장소 정답 이름
                    correct++;
            }

            TableAnswer.placementCardCount = 0;
            TableAnswer.answerCount = 0;

            if (correct == SlotCount)
            {
                TableAnswer.OpenDoor();
                Item_true_bgm.GetComponent<AudioSource>().Play();
                return;
            }

            // 오답: 카드를 전부 되돌리고 칸을 비운다
            Item_false_bgm.GetComponent<AudioSource>().Play();
            ResetCards();
        }

        void ResetCards()
        {
            foreach (var pair in placed)
            {
                GameObject card = pair.Value;
                card.GetComponent<SpriteRenderer>().enabled = true;
                card.GetComponent<BoxCollider2D>().enabled = true;
                pair.Key.GetComponent<SpriteRenderer>().sprite = null;
            }
            placed.Clear();

            // 손에 든 카드가 있으면 그것도 되돌린다
            if (isGetItem && getItem != null)
            {
                getItem.GetComponent<SpriteRenderer>().enabled = true;
                getItem.GetComponent<BoxCollider2D>().enabled = true;
            }
            ClearHand();
        }

        // 씬을 다시 시작할 때 static 상태가 남지 않도록 초기화
        void OnDestroy()
        {
            if (placed.Count > 0 || isGetItem)
            {
                // 씬 언로드 시 한 번만 정리되면 충분하다
                placed.Clear();
                isGetItem = false;
                getItem = null;
            }
        }
    }
}
