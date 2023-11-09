using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{

    public List<GameObject> platforms = new List<GameObject>();
    public List<Transform> currentPlatforms = new List<Transform>();

    public int offset;

    private Transform vehicle;
    private Transform currentPlatformPoint;
    private int platformIndex;
    
    void Start()
    {

        vehicle = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < platforms.Count; i++)
        {
            Transform p = Instantiate(platforms[i], new Vector3(0, 0, i * 204), transform.rotation).transform;
            currentPlatforms.Add(p);
            offset += 204;
        }

        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().point;
        
    }

    void Update()
    {
        float distance = vehicle.position.z - currentPlatformPoint.position.z;

        if (distance >= 5)
        {
            Recycle(currentPlatforms[platformIndex].gameObject);
            platformIndex++;

            if(platformIndex > currentPlatforms.Count -1) 
            {
                platformIndex = 0;
            }

            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().point;
        }
    }

    public void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector3(0, 0, offset);
        offset += 204;
    }
}
