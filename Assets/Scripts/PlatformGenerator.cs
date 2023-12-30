using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] Transform folder;
    [SerializeField] GameObject platformPrefab;
    [SerializeField] int maxGenCount = 20;
    [SerializeField] float posXLimit = 7.5f;
    [SerializeField] float maxIntervalX = 4f;
    [SerializeField] float minIntervalY = 2f;
    [SerializeField] float maxintervalY = 3f;

    Vector2 lastGenPos;

    private void Awake()
    {
        lastGenPos = Vector2.zero;
        for (int curCount = 0; curCount < maxGenCount; curCount++)
        {
            GameObject platform = Instantiate(platformPrefab);
            platform.transform.parent = folder;

            lastGenPos.x += Random.Range(-maxIntervalX, maxIntervalX);
            lastGenPos.y += Random.Range(minIntervalY, maxintervalY);
            if(lastGenPos.x < -posXLimit)
            {
                lastGenPos.x = -posXLimit;
            }
            else if(lastGenPos.x > posXLimit)
            {
                lastGenPos.x = posXLimit;
            }

            platform.transform.position = lastGenPos;
        }
    }
}