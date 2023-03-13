using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class EachRabbitTouch : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Item.instance.isGetItem == false)
        {
            GameObject.Find("getRabbitBgm").GetComponent<AudioSource>().Play();
            Item.instance.Get_Item(this.gameObject);
        }
        else
        {
            Item.instance.Push_Item(this.gameObject);
        }
    }
}
