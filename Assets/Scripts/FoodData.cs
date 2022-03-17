using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FoodData", menuName = "Food Data", order = 51)]
public class FoodData : ScriptableObject
{
    [SerializeField]
    private string foodName;
    [SerializeField]
    private string description;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private float value;

    public string FoodName
    {
        get { return FoodName; }
    }

    public string Description
    {
        get { return description; }
    }

    public Sprite Icon
    {
        get { return icon; }
    }

    public float Value
    {
        get { return value; }
    }

}
