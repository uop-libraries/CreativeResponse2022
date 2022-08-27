using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
// This is the splash page that will be revealed when first opening the app.
// It will reveal itself only once and never again unless the app is reset.
// This shows the spash pages that tell the user the app has sound.
// In retrospect I could have had both pre-title-screen splash pages handled in the same script rather than two separate ones, (their timers
// offset from one another to play in a sequence)...
// I'm sorry I didn't ... its so scuffed in practice... 
// Also also this is straight up taken from the pacific weekly script, i didnt even bother renaming the variables LOL im sorry....
public class PrePreTitleScreenFade : MonoBehaviour
{
    public GameObject PacificWeeklyWhole, PacificWeeklyCover, JustString, Canvas, Disable, Cover;
    private Image PacificWeeklyCoverImage;
    public float timer = 3;
    private Color TempColor;
    private static bool PlayCheck = false;
    private PrePreTitleScreenFade yeh;
    void Start()
    {
        // this try-catch is here to prevent the null reference error after trying to load it a second time.
        // it will not load a second time because everything will be perma-set to inactive.
        try
        {
            Canvas.GetComponent<PreTitleScreenFade>();
            if (PlayCheck)
            {
                Disable.SetActive(false);
                Cover.SetActive(false);
                yeh.enabled = false;
            }
            else
            {
                PacificWeeklyCoverFade();
                StartCoroutine(ExampleCoroutine());
                PlayCheck = true;
            }
        }
        catch (NullReferenceException e)
        {

        }
    }

    void PacificWeeklyCoverFade()
    {
        PacificWeeklyCoverImage = PacificWeeklyCover.GetComponent<Image>();
        TempColor = PacificWeeklyCover.GetComponent<Image>().color;
        // initialize the cover that covers the splash page as visible
        TempColor.a = 1;
        PacificWeeklyCover.GetComponent<Image>().color = TempColor;
    }

    IEnumerator ExampleCoroutine()
    {
        // fade away the cover page, revealing the splash page contents
        PacificWeeklyCoverImage.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(timer);
        // after some time has passed, fade in the cover image again
        PacificWeeklyCoverImage.CrossFadeAlpha(0.5f, 1f, false);
        // then set the whole thing, splash page contents and splash page cover inactive.
        PacificWeeklyWhole.SetActive(false);
        // uhhh the string variable was left in here and i didnt bother to remove it, so theres prolly a placeholder gameobject
        // to keep it from fighting me
        JustString.SetActive(false);
    }
}
