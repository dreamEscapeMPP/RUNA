using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stroy;

namespace ItemNewCsNamespace
{
    public class TableAnswer : MonoBehaviour
    {
        public static TableAnswer Instances;
        public static int answerCount = 0;
        public static int placementCardCount = 0;
        bool anserCountCheck = true;

        private void Awake()
        {
            Instances = this;
        }
        public static void OpenDoor()
        {
            GameObject door;
            door = GameObject.Find("door");
            door.GetComponent<NextScene.ClearNNext>().Change_backgournd_Sprite();
        }
    }
}
