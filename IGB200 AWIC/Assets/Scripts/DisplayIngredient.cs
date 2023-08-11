using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayIngredient : MonoBehaviour
{
    public Ingredient Ingredient;
    
    // Start is called before the first frame update
    void Start()
    {
        Ingredient.Print();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
