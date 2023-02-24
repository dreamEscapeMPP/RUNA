using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToAnim : MonoBehaviour
{
    void OnMouseDown()
    {
        gameObject.GetComponent<Animator>().Play(gameObject.name.ToString());
    }
}
