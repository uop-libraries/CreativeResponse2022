//Attatch this script to a Button GameObject
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateOnClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject rotatedObject;
    public float rotationSpeed = 10000;
    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Use this to tell when the user left-clicks on the Button
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
                rotatedObject.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
}