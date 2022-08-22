using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;

public class NoNoInteraction : MonoBehaviour
{
    [SerializeField] private GameObject context;
    [SerializeField] private GameObject back;
    [SerializeField] private GameObject hamburger;
    //[SerializeField] private GameObject continueButton;

    [SerializeField] private SwitchManager switch1;
    [SerializeField] private SwitchManager switch2;
    [SerializeField] private SwitchManager switch3;
    [SerializeField] private SwitchManager switch4;
    // Start is called before the first frame update
    void Start()
    {
        context.SetActive(false);
        back.SetActive(false);
        hamburger.SetActive(false);
        //continueButton.SetActive(false);
    }

    void FixedUpdate()
    {
        if (switch1.isOn == true && switch3.isOn == true ||
            switch1.isOn == true && switch4.isOn == true ||
            switch2.isOn == true && switch3.isOn == true ||
            switch2.isOn == true && switch4.isOn == true)
        {
            context.SetActive(true);
            back.SetActive(true);
            hamburger.SetActive(true);
            //continueButton.SetActive(true);
        }

    }

}
