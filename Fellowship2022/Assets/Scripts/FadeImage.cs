using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// FOR OBJECTS WITH AN IMAGE COMPONENT
// this script makes the specified object completely transparent on load,
// and then tweens back to visibility.
// (used together with the MoveObjext script)
public class FadeImage : MonoBehaviour
{
    public GameObject Object;
    Color newColor;
    public float FadeTime = 1.5f;
    public float WaitTime = 2f;
    // True = Fade In
    // False = Fade Out
    public bool InorOut = true;
    //private Image temp;
    private Image temp2;

    private void Start()
    {
        temp2 = Object.GetComponent<Image>();
        // for buttons (the text of the buttons are not affected by this script, add the FadeInText with this too.)
        StartCoroutine(ExampleCoroutine());
    }


    IEnumerator ExampleCoroutine()
    {
        //temp = Object.GetComponent<Image>();

        if (InorOut)
        {
            temp2.CrossFadeAlpha(0.0f, 0.0f, false);
            FadeIn();
        }
        else
        {
            yield return new WaitForSeconds(WaitTime);
            FadeOut();
        }
    }

    private void FadeIn()
    {
        temp2.CrossFadeAlpha(1.0f, FadeTime, false);
    }

    private void FadeOut()
    {
        temp2.CrossFadeAlpha(0.0f, FadeTime, false);
    }
}
