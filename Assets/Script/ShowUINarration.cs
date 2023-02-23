using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Stroy;

namespace WhileStroy
{
    public class ShowUINarration : MonoBehaviour
    {
        public string showNarrationdDetail;
        public bool showCharCheck = false;
        public Image ShowCharImage;
        public GameObject showChatUI;

        Narration UInar;
        private GameObject NarrationManage;

        void OnMouseDown()
        {
            StartCoroutine(ShowNarration(showNarrationdDetail));
        }

        public IEnumerator ShowNarration(string showNarrationdDetails)
        {
            NarrationManage = GameObject.Find("GameManage");

            UInar = NarrationManage.GetComponent<FitstStory>().narration;
            OnCollider();
            UInar.UI_On();
            if (showCharCheck)
            {
                UInar.Right_Image_set(ShowCharImage);
            }
            GameObject.Find("TextName").GetComponent<Text>().text = "system";
            NarrationManage.GetComponent<AudioSource>().Play();
            yield return StartCoroutine(UInar.Chat(showNarrationdDetails, 0.5f));
            NarrationManage.GetComponent<AudioSource>().Pause();
            UInar.UI_Off();
            OffCollider();
        }
        public void OffCollider()
        {
            if (showChatUI == null)
                showChatUI = GameObject.Find("ChatUICanvas").transform.GetChild(1).gameObject;
            showChatUI.SetActive(false);
        }
        public void OnCollider()
        {
            if (showChatUI == null)
                showChatUI = GameObject.Find("ChatUICanvas").transform.GetChild(1).gameObject;
            showChatUI.SetActive(true);
        }

    }
}