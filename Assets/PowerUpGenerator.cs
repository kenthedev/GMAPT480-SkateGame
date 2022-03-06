using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{
    public GameObject[] powerUp;


    public float coundownspee;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coundownspee -= Time.deltaTime;
        if (coundownspee <= 0)
        {
            GeneratePowerup();
            coundownspee = 5f;
        }
        Debug.Log(coundownspee);
    }
    public void GeneratePowerup()
    {
        int Randmo = Random.Range(0, 2);
        Debug.Log("random works" + Randmo);
        Instantiate(powerUp[Randmo], transform.position, transform.rotation);
    }

}
