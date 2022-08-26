using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class VideoFadeIn : MonoBehaviour
{
    public GameObject LanternVideoObject;
    private RawImage LanternVideoObjectImage;
    private Color TempColor, TempColor2;

    void Start()
    {
        FadeInLanterns();
        StartCoroutine(ExampleCoroutine());
    }
    void FadeInLanterns()
    {
        LanternVideoObjectImage = LanternVideoObject.GetComponent<RawImage>();
        LanternVideoObjectImage.CrossFadeAlpha(0, 0f, false);
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        LanternVideoObjectImage.CrossFadeAlpha(1, 3f, false);
        yield return new WaitForSeconds(26);
        LanternVideoObjectImage.CrossFadeAlpha(0, 2f, false);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Title");
    }
}
