using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrePreTitleScreenFade : MonoBehaviour
{
    public GameObject PacificWeeklyWhole, PacificWeeklyCover, JustString;
    private Image PacificWeeklyCoverImage;
    public float timer = 3;
    private Color TempColor;
    void Start()
    {
        PacificWeeklyCoverFade();
        StartCoroutine(ExampleCoroutine());
    }

    void PacificWeeklyCoverFade()
    {
        PacificWeeklyCoverImage = PacificWeeklyCover.GetComponent<Image>();
        TempColor = PacificWeeklyCover.GetComponent<Image>().color;
        TempColor.a = 1;
        PacificWeeklyCover.GetComponent<Image>().color = TempColor;
    }

    IEnumerator ExampleCoroutine()
    {
        PacificWeeklyCoverImage.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(timer);
        PacificWeeklyCoverImage.CrossFadeAlpha(0.5f, 1f, false);
        PacificWeeklyWhole.SetActive(false);
        //yield return new WaitForSeconds(1);
        JustString.SetActive(false);
    }
}
