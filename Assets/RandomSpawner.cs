using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField]
    float[] percentages;
    [SerializeField]
    GameObject[] objectsToSpawn;
    [SerializeField]
    Transform spawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(objectsToSpawn[GetRandomSpawn()], spawnPoint);
        }
    }

    private int GetRandomSpawn()
    {
        float random = UnityEngine.Random.Range(0f, 1f);
        float numForAdding = 0;
        float total = 0;
        for (int i = 0; i < percentages.Length; i++)
        {
            total += percentages[i];
        }

        for (int i = 0; i < objectsToSpawn.Length; i++)
        {
            if (percentages[i] / total + numForAdding >= random)
            {
                return i;
            }
            else
            {
                numForAdding += percentages[i] / total;
            }
        }
        return 0;
    }

}
