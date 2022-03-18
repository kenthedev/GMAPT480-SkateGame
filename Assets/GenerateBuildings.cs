using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBuildings : MonoBehaviour
{

    public GameObject[] city;


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
            GenerateCity();
            coundownspee = 10f;
        }
        // Debug.Log(coundownspee);
    }

    public void GenerateCity()
    {
        int Randmo = Random.Range(0, 3);
        Instantiate(city[Randmo], transform.position, transform.rotation);
    }
}
