using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchOnOff : MonoBehaviour
{
    private int Child_Count = 0;
    void Start()
    {
        Child_Count = gameObject.transform.childCount;
        OffEnableColider2D();
    }

    public void OnEnableColider2D(GameObject gameObjects)
    {
        Child_Count = gameObjects.transform.childCount;
        for (int i = 0; i < Child_Count; i++)
        {
            if (gameObjects.transform.GetChild(i).name != "door_open")
                if (gameObjects.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>() != null)
                    gameObjects.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    public void OnEnableColider2D()
    {
        for (int i = 0; i < Child_Count; i++)
        {
            if (transform.GetChild(i).name != "door_open")
                if (transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>() != null)
                    transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = true;
            if(transform.GetChild(i).name == "door")
                transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void OffEnableColider2D(GameObject gameObjects)
    {
        Child_Count = gameObjects.transform.childCount;
        for (int i = 0; i < Child_Count; i++)
        {
            if (gameObjects.transform.GetChild(i).name != "door_open")
                if (gameObjects.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>() != null)
                    gameObjects.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    public void OffEnableColider2D()
    {
        for (int i = 0; i < Child_Count; i++)
        {
            if (transform.GetChild(i).name != "door_open")
                if (transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>() != null)
                    transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
