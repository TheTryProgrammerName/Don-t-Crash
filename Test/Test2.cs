using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
        keyValuePairs["12"] = "121";
        Debug.Log(keyValuePairs["12"]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
