using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("City"))
        {
            Destroy(this.gameObject);
        }
    }
}
