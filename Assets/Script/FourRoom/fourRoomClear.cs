using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fourRoomClear : MonoBehaviour
{
    public GameObject door;
    public GameObject doorOpen;
    public GameObject doorZoom;
    // Start is called before the first frame update
    void Start()
    {
        password_locke.ClearStage = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (password_locke.ClearStage == true)
        {
            door.GetComponent<BoxCollider2D>().enabled = false;
            doorOpen.GetComponent<NextScene.ClearNNext>().Change_backgournd_Sprite();
            doorZoom.GetComponent<NextScene.ClearNNext>().Change_backgournd_Sprite();
        }
    }
}
