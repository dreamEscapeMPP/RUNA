using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveRoomClearADD : MonoBehaviour
{

    public static bool ClearStage = false;

    public GameObject door;
    public GameObject doorOpen;
    public GameObject doorZoom;
    // Start is called before the first frame update
    void Start()
    {
        ClearStage = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ClearStage == true)
        {
            door.GetComponent<BoxCollider2D>().enabled = false;
            doorOpen.GetComponent<BoxCollider2D>().enabled = true;
            doorOpen.GetComponent<NextScene.ClearNNext>().Change_backgournd_Sprite();
            //doorZoom.GetComponent<NextScene.ClearNNext>().Change_backgournd_Sprite();
            ClearStage = false;
        }
    }
}
