using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PreTitleScreenFade : MonoBehaviour
{
    public GameObject PacificWeeklyWhole, PacificWeeklyCover, BioCover, JustString, Canvas, Disable, Cover;
    public float timer = 3;
    public float timer2 = 6;
    private Image PacificWeeklyCoverImage, BioCoverImage;
    private Color TempColor;
    private static bool PlayCheck = false;
    private PreTitleScreenFade yeh;
    void Start()
    {
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
                BioCoverFade();
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
        yield return new WaitForSeconds(timer);
        PacificWeeklyCoverImage.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(timer2);
        PacificWeeklyCoverImage.CrossFadeAlpha(0.5f, 1f, false);
        PacificWeeklyWhole.SetActive(false);
        BioCoverImage.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(1f);
        BioCover.SetActive(false);
        //JustString.SetActive(false);
    }
}
