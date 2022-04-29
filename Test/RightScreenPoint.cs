using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightScreenPoint : MonoBehaviour
{
    public Camera Camera;

    void Start()
    {
        Debug.Log(Camera.ScreenToWorldPoint(new Vector3(0, Screen.height, 100f)).x - 2.05f);
    }

}
