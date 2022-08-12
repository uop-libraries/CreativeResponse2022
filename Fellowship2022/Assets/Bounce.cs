using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObj : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    public GameObject obj;
    void Start()
    {
        horizontalInput = obj.transform.position.x;
        verticalInput = obj.transform.position.y;
        StartBouncing();
    }
    public void StartBouncing()
    {
        transform.LeanMoveLocal(new Vector2(horizontalInput-720, verticalInput-1500), 1).setEaseOutQuart().setLoopPingPong();
    }
}
