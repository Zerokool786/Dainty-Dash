using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 tileSize = GetComponent<Renderer>().bounds.size;
        Debug.Log(tileSize.x);
        Debug.Log(tileSize.y);
        Debug.Log(tileSize.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
