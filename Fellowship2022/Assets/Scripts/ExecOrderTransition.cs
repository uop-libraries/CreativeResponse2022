using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
// This is the script that is assigned to a button on click event. When clicked, it plays the transition of the string
// going downwards until it reaches the executive order page, then automatically switches scenes to the executive order
// scene.
public class ExecOrderTransition : MonoBehaviour
{
    public float Time = 3f;
    public float distance;
    float x, y;
    public GameObject BioContent;
    // Get the initial position of the game object parent containing everything related to the bio content of the person.
    private void Start()
    {
        x = BioContent.transform.position.x;
        y = BioContent.transform.position.y;
    }
    // On click, slide the bio content parent upwards by an adjustable distance variable multiplied by its initial y value.
    public void BeginTransition()
    {
        BioContent.transform.DOMove(new Vector2(x, (distance * y)), Time);
        Debug.Log(distance * y);
        StartCoroutine(ExampleCoroutine());
    }
    // Wait for 5 seconds so the user can get a good look at the exec order paper before automatically changing the scene
    // to the executive order scene.
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Executive Order 9066");
    }
}
