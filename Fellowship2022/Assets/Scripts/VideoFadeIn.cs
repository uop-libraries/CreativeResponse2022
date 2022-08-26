using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
// This is like the same as FadeImage.cs but with a RawImage rather than just an Image variable type. Initializes invisible,
// fades in, then fades out.
public class VideoFadeIn : MonoBehaviour
{
    public GameObject LanternVideoObject;
    private RawImage LanternVideoObjectImage;

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
        yield return new WaitForSeconds(27);
        LanternVideoObjectImage.CrossFadeAlpha(0, 3f, false);
        yield return new WaitForSeconds(3);
        //Debug.Log("done");
        SceneManager.LoadScene("Title");
    }
}
