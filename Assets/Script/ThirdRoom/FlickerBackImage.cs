using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerBackImage : MonoBehaviour
{
    public Sprite changeImage;
    public Sprite OrignBackImage;
    public GameObject changeObj;
    public bool requirement = false;
    public bool isTurnBGM = false;

    void OnMouseDown()
    {
        if (!requirement)
            StartCoroutine(FlickerImage());
    }

    public IEnumerator FlickerImage()
    {
        if(isTurnBGM) this.gameObject.GetComponent<AudioSource>().Play();
        changeObj.GetComponent<SpriteRenderer>().sprite = changeImage;
        yield return new WaitForSeconds(0.3f);
        changeObj.GetComponent<SpriteRenderer>().sprite = OrignBackImage;
        yield return new WaitForSeconds(0.2f);
        changeObj.GetComponent<SpriteRenderer>().sprite = changeImage;
        yield return new WaitForSeconds(0.3f);
        changeObj.GetComponent<SpriteRenderer>().sprite = OrignBackImage;
        yield return new WaitForSeconds(0.2f);
        changeObj.GetComponent<SpriteRenderer>().sprite = changeImage;
        yield return new WaitForSeconds(0.2f);
        changeObj.GetComponent<SpriteRenderer>().sprite = OrignBackImage;
        yield return new WaitForSeconds(0.3f);
        changeObj.GetComponent<SpriteRenderer>().sprite = changeImage;
        yield return new WaitForSeconds(10f);
    }
}
