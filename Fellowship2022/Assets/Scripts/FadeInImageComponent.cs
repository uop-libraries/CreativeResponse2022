using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// FOR OBJECTS WITH AN IMAGE COMPONENT
// this script makes the specified object completely transparent on load,
// and then tweens back to solid visibility.
// (used together with the MoveObjext script)
public class FadeInImageComponent : MonoBehaviour
{
    public GameObject Object;
    Color newColor;
    public float DelayTime = 1.5f;
    private void Start()
    {
        // for buttons (the text of the buttons are not affected by this script, add the FadeInText with this too.)
        var temp = Object.GetComponent<Image>();
            
        temp.CrossFadeAlpha(0.0f, 0.0f, false);
        temp.CrossFadeAlpha(1.0f, DelayTime, false);
    }
}
