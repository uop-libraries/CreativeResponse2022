using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// This script will play every time specific scenes are loaded, manually placed in whatever scene it's needed in.
// It's an overlaid splash page that initializes invisible, fades in, waits a bit, then fades out revealing 
// the actual content of the page.
// Not gonna lie its a little scuffed, there are two game object images that are just solid colors. One that initially covers
// the splash page contents then fades away revealing it, and one that covers the bio content then fades away revealing it (after the
// aforementioned splash page completely fades away).
// In retrospect I think I could have made due with only a single cover image but I guess I wasn't thinking hard enough at the time lol.
// Also the string is overlaid and visible every time. There is a string object overlaying the splash page, and one overlaying the bio content.
// When the splash page fades away, so is the string overlaying on it, revealing the string overlaying the bio content.
// Once again its definitely not the best way to do it but I admit I was not thinking hard enough.
public class PacificWeeklyFade : MonoBehaviour
{
    public GameObject PacificWeeklyWhole, PacificWeeklyCover, BioCover, JustString;
    private Image PacificWeeklyCoverImage, BioCoverImage;
    private Color TempColor;
    void Start()
    {
        PacificWeeklyCoverFade();
        BioCoverFade();
        StartCoroutine(ExampleCoroutine());
    }
    void PacificWeeklyCoverFade()
    {
        PacificWeeklyCoverImage = PacificWeeklyCover.GetComponent<Image>();
        TempColor = PacificWeeklyCover.GetComponent<Image>().color;
        // initialize the cover for the spash page to be visible, covering everything
        TempColor.a = 1;
        PacificWeeklyCover.GetComponent<Image>().color = TempColor;
    }
    void BioCoverFade()
    {
        BioCoverImage = BioCover.GetComponent<Image>();
        TempColor = BioCover.GetComponent<Image>().color;
        // initialize the cover for the bio page to be visible, covering everything
        TempColor.a = 1;
        BioCoverImage.GetComponent<Image>().color = TempColor;
    }

    IEnumerator ExampleCoroutine()
    {
        // fade away and make invisible the cover for the splash page overlay
        PacificWeeklyCoverImage.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(2);
        // after 2 seconds make the splash page cover visible
        PacificWeeklyCoverImage.CrossFadeAlpha(1, 1f, false);
        // and disable everything related to the splash cover page

        // fade away and make invisible the cover for the bio page overlay
        PacificWeeklyWhole.SetActive(false);
        BioCoverImage.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(1);
        // after completely fading away, set the cover inactive otherwise the user cant tap on anything cause its still covering like
        // the whole page. 
        BioCover.SetActive(false);
        // also disable the string image that overlaid the pacific weekly splash page for reasons mentioned 3 lines above.
        JustString.SetActive(false);
    }
}
