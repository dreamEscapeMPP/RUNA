using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAllCheck : MonoBehaviour
{

    public GameObject card1_shows;
    public GameObject card2_shows;
    public GameObject card3_shows;
    public GameObject card4_shows;
    private bool Check_backImage = true;
    // Update is called once per frame
    void Update()
    {
        if (Check_backImage)
        {
            if (card1_shows.GetComponent<BoxCollider2D>().isActiveAndEnabled == true &&
    card2_shows.GetComponent<BoxCollider2D>().isActiveAndEnabled == true &&
    card3_shows.GetComponent<BoxCollider2D>().isActiveAndEnabled == true &&
    card4_shows.GetComponent<BoxCollider2D>().isActiveAndEnabled == true)
                StartCoroutine(GameObject.Find("background").GetComponent<FlickerBackImage>().FlickerImage());

        }
    }
}
