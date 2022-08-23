using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ExecOrderTransition : MonoBehaviour
{
    public float Time = 3f;
    public float distance;
    float x, y;

    public GameObject BioContent;

    private void Start()
    {
        x = BioContent.transform.position.x;
        y = BioContent.transform.position.y;
    }
    public void BeginTransition()
    {
        BioContent.transform.DOMove(new Vector2(x, (distance * y)), Time);

        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Executive Order 9066");
    }
}
