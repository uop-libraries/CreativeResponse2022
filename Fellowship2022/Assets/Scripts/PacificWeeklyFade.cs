using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        TempColor.a = 1;
        PacificWeeklyCover.GetComponent<Image>().color = TempColor;
    }
    void BioCoverFade()
    {
        BioCoverImage = BioCover.GetComponent<Image>();
        TempColor = BioCover.GetComponent<Image>().color;
        TempColor.a = 1;
        BioCoverImage.GetComponent<Image>().color = TempColor;
    }

    IEnumerator ExampleCoroutine()
    {
        PacificWeeklyCoverImage.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(2);
        PacificWeeklyCoverImage.CrossFadeAlpha(1, 1f, false);
        PacificWeeklyWhole.SetActive(false);
        BioCoverImage.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(1);
        BioCover.SetActive(false);
        JustString.SetActive(false);
    }
}
