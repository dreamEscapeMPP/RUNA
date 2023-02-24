using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlacement : MonoBehaviour
{
    void OnMouseDown()
    {
        GameObject.Find(gameObject.name.ToString() + "_show").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find(gameObject.name.ToString() + "_show").GetComponent<BoxCollider2D>().enabled = true;
    }
}

