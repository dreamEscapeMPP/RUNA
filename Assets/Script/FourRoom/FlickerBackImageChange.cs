using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerBackImageChange : FlickerBackImage
{
    //overriding
    void OnMouseDown()
    {
        StartCoroutine(FlickerImage());
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
