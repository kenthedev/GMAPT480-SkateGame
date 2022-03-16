using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllingTheAnimation : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.instance.isgrounded == false)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }

        if (Player.instance.isgrounded == true)
        {
            anim.SetBool("Speed", false);
        }
        else
            anim.SetBool("Speed", true);
    }
}
