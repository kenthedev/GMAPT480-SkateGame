using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject Spike;

    public float MinSpeed;
    public float MaxSpeed;
    public float CurrentSpeed;

    public float speedmultiplier;
    // Start is called before the first frame update
    void Start()
    {
        CurrentSpeed = MinSpeed;
        GenerateSpike();
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentSpeed < MaxSpeed)
        {
            CurrentSpeed += speedmultiplier;
        }
    }

    public void GenerateSpike()
    {
        GameObject spikeIns = Instantiate(Spike, transform.position, transform.rotation);
        spikeIns.GetComponent<SpikeScript>().spikegenerator = this;
    }

    public void Generate()
    {
        float random = Random.Range(0.1f, 1.2f);
        Invoke("GenerateSpike", random);
    }
}
