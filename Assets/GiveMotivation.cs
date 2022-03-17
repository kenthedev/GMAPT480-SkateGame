using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveMotivation : MonoBehaviour
{
    public GameObject motivations;
    public GameObject moving;
    public GameObject going;
    public GameObject nice;
    public GameObject star;
    public GameObject super;
    public List<GameObject> motivationalList = new List<GameObject>();
    float startTime = 0f;
    float endTime = 15f;
    // Start is called before the first frame update
    void Start()
    {
        motivationalList.Add(moving);
        motivationalList.Add(going);
        motivationalList.Add(nice);
        motivationalList.Add(star);
        motivationalList.Add(super);
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        if (startTime >= endTime)
        {
            StartCoroutine(DisplayMotivation());
            startTime = 0f;
        }
        
    }

    public IEnumerator DisplayMotivation()
    {
        int randomNum = Random.Range(0, 4);
        motivationalList[randomNum].SetActive(true);
        yield return new WaitForSeconds(4);
        motivationalList[randomNum].SetActive(false);
    }
}
