using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 100f;
    public static Timer instance;

    [SerializeField] Text countdownText;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }    
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
        if(currentTime<=0)
        {
            currentTime = 0;
        }
    }
}
