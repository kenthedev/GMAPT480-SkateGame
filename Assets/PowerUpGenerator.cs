using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class colorToPrefab
{
    public GameObject[] prefab;
    public Color color;
}

public class PowerUpGenerator : MonoBehaviour
{
    public static PowerUpGenerator instance;
    public GameObject[] powerUp;

    public bool mapUsed = false;
    public Texture2D foodMap;

    public colorToPrefab[] colortoPrefab;
    public GameObject parentObj;

    public float countdownSpeed;
    public float MaxSpeed;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdownSpeed -= Time.deltaTime;
        if (countdownSpeed <= 0)
        {
            int randNo = Random.Range(0, 6);
            Debug.Log("random works" + randNo);

            if (randNo == 0) // 0 is the bottle
            {
                GeneratePowerup(randNo);
            }

            else if (mapUsed)
            {
                GenerateMap(randNo);
                mapUsed = false;
            }
            
            else
            {
                GeneratePowerup(randNo);
                mapUsed = true;
            }
            
            countdownSpeed = MaxSpeed;
        }
        Debug.Log(countdownSpeed);
    }
    public void GeneratePowerup(int randNo)
    {
        Instantiate(powerUp[randNo], transform.position, transform.rotation);
    }
 
    void GenerateMap(int randNo)
    {
        for (int x = 0; x < foodMap.width; x++)
        {
            for (int y = 0; y < foodMap.height; y++)
            {
                GenerateFoods(x, y, randNo);
            }
        }
    }

    void GenerateFoods(int x, int y, int food)
    {
        Color mapColor = foodMap.GetPixel(x, y);
        
        foreach (colorToPrefab obj in colortoPrefab)
        {
            if (obj.color.Equals(mapColor))
            {
                Vector2 pos = new Vector2(x, y - 3);
                Instantiate(obj.prefab[food], pos, Quaternion.identity, parentObj.transform);
            }
        }
    }
    
}
