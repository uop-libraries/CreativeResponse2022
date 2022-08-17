using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DaIcon : MonoBehaviour
{
    public GameObject Obj;
    public float Time;
    float x, y;

    void Start()
    {
        x = Obj.transform.position.x;
        y = Obj.transform.position.y;
        // boing boing
        Obj.transform.DOMove(new Vector2(x, y + (0.05f * y)), Time).SetLoops(-1, LoopType.Yoyo);
    }


}
