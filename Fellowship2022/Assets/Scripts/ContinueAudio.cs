using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueAudio : MonoBehaviour
{
   public string tagSpecification;
   private void Awake()
   {
      GameObject[] musicObject = GameObject.FindGameObjectsWithTag(tagSpecification);
      if (musicObject.Length > 1)
      {
         Destroy(this.gameObject);
      }
      DontDestroyOnLoad(this.gameObject);
   }
}
