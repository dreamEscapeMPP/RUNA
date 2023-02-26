using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NextScene;

public class ClickKey : MonoBehaviour
{
    public GameObject door;
    void OnMouseDown()
    {
        door.GetComponent<ClearNNext>().Change_backgournd_Sprite();
    }
}
