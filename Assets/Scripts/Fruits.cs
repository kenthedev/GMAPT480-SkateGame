using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public bool[] Fruittopick;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Avocado
            if(Fruittopick[0])
            {
                Player.instance.Score += 1000;
                Destroy(this);
            }
            //Lemon
            else if(Fruittopick[1])
            {
                Player.instance.Score += 2000;
                Destroy(this);
            }
            //Grapes
            else if(Fruittopick[2])
            {
                Player.instance.Score += 3000;
                Destroy(this);
            }
            //Eggplant
            else if(Fruittopick[3])
            {
                Player.instance.Score += 4000;
                Destroy(this);
            }
            //Pear
            else if(Fruittopick[4])
            {
                Player.instance.Score += 5000;
                Destroy(this);
            }
            //Banana
            else if(Fruittopick[5])
            {
                Player.instance.Score += 6000;
                Destroy(this);
            }
            //Cherry
            else if(Fruittopick[6])
            {
                Player.instance.Score += 7000;
                Destroy(this);
            }
        }
    }
}
