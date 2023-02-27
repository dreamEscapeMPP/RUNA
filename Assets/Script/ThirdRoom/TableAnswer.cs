using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableAnswer : MonoBehaviour
{
    public static int answerCount = 0;
    public static int placementCardCount = 0;
    bool anserCountCheck = true;

    public static void OpenDoor()
    {
        GameObject door;
        door = GameObject.Find("door");
        door.GetComponent<NextScene.ClearNNext>().Change_backgournd_Sprite();
    }
}
