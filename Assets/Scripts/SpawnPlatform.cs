using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{

    public List<GameObject> platforms = new List<GameObject>();
    public int offset;
    void Start()
    {
        for(int i = 0; i < platforms.Count; i++)
        {
            Instantiate(platforms[i], new Vector3(0,0,0), transform.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
