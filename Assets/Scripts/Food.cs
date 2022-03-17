using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    private string FoodName;
    private string description;
    private Sprite icon;
    private float value;

    public void CreateFood(FoodData data)
    {
        this.FoodName = data.FoodName;
        this.description = data.Description;
        this.icon = data.Icon;
        this.value = data.Value;
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * 2);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.Score += value;
            Destroy(this.gameObject);
        }
    }
}
