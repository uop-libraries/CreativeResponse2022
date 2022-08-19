using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

//[RequireComponent(typeof(InputField))]
public class InputFieldText : MonoBehaviour
{

    string content;
    public TMP_InputField obj;

    InputField field;

    // Use this for initialization
    void Start()
    {
        field = obj.GetComponent<InputField>();
        content = field.text;
        field.onValueChanged.AddListener(s => field.text = content);
    }
}