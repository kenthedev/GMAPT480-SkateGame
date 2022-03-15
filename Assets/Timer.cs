using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float currentTime = 0f;
    //The max time that the player will play
    public float startingTime;
    public static Timer instance;

    // [SerializeField] Text countdownText;

    // progress bar
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Slider timerSlider;
    public Text timerText;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //currentTime = startingTime;
        timerSlider = GameObject.Find("GameLogic").GetComponent<Timer>().timerSlider;
        // Progress Bar
        timeRemaining = startingTime;
        timerIsRunning = true;
        timerSlider.maxValue = timeRemaining;
        timerSlider.value = timeRemaining;

    }

    // Update is called once per frame
    void Update()
    {

        /*
        // Countdown
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
        if(currentTime<=0)
        {
            currentTime = 0;
        } */

        // Progress Bar

        float timeToDisplay = startingTime - Time.time;
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        string textTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                GameObject.Find("GameLogic").GetComponent<Timer>().timerText.text = textTime;
                GameObject.Find("GameLogic").GetComponent<Timer>().timerSlider.value = timeToDisplay;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }

    }

}
