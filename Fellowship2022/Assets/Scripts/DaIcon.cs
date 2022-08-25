using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;

public class DaIcon : MonoBehaviour
{
    public GameObject Obj;
    public float Time;
    public bool toggle = false;
    float x, y;
    private static Vector2 scale;

    void Start()
    {
        if (!toggle)
        {
            DaIconBounce();
        }
        else
        {
            Amogus();
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Japanese Club")
        {
            if (Input.GetMouseButton(0))
            {
                //Debug.Log("down");
                Obj.transform.localScale = new Vector2(scale.x, scale.y);
            }
            else
            {
                //Debug.Log("up");
                Obj.transform.localScale = new Vector2(0f, 0f);
            }
        }
    }

    void DaIconBounce()
    {
        x = Obj.transform.position.x;
        y = Obj.transform.position.y;
        // boing boing
        Obj.transform.DOMove(new Vector2(x, y + (0.05f * y)), Time).SetLoops(-1, LoopType.Yoyo);
    }

    void Amogus()
    {
        scale = Obj.transform.localScale;
        Obj.transform.localScale = new Vector2(0f,0f);
    }
}
