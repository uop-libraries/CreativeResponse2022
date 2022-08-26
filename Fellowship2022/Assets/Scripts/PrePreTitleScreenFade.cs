using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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
