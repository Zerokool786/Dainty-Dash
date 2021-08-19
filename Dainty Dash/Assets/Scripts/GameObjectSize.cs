using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 tileSize = GetComponent<Renderer>().bounds.size;
        Debug.Log(tileSize.x);   //2.137795
        Debug.Log(tileSize.y);   //0.7175648
        Debug.Log(tileSize.z);   //3.798935
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
