using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;

public class Cook : MonoBehaviour
{
    public Ingredient ingredient;
    public Pie pie;
    public GameObject pieObject;
    
    // Start is called before the first frame update
    void Start()
    {
        pie = pieObject.GetComponent<Pie>();
    }

    // Update is called once per frame
    void Update()
    {
        // If pie is complete, instantiate the pie & reset values of prefab
       if(PieCompleted())
        {
            Debug.Log("Complete");
            Instantiate(pieObject, this.transform);
            pie.pbase = "Default";
            pie.filling = "Default"; 
            pie.top = "Default";
            
        } 
    }
    
    public void OnTriggerEnter(Collider other)
    {
        ingredient = other.GetComponent<Ingredient>();
        if (other.gameObject.tag == "Ingredient")
        {
            string category = ingredient.category;
            AssemblePie(category);
            Destroy(other.gameObject);
        }


    }
    public void OnMouseDown()
    {
        Debug.Log($"{pie.pbase}, {pie.filling}, {pie.top}");
    }
    public void AssemblePie(string category)
    {
        
            switch (category)
            {
                case "Base":
                    // If pie already has a base
                    if (pie.pbase != "Default")
                    {
                        Debug.Log($"Base already present");
                        break;
                    }
                    else
                    {
                        pie.pbase = ingredient.name; 
                        Debug.Log($"New Base : {pie.pbase}");
                    }

                    break;

                case "Filling":
                    // If Pie already contains filling
                    if (pie.filling != "Default")
                    {
                        Debug.Log($"Filling already present");
                        break;
                    }
                    // If Pie has base
                    if (pie.pbase != "Default")
                    {
                        pie.filling = ingredient.name;
                        Debug.Log($"New Filling : {pie.filling}");
                    }
                    else
                    {
                        Debug.Log("Add a base first");
                    }
                    break;

                case "Top":
                    // If Pie already contains a top
                    if (pie.top != "Default")
                    {
                        Debug.Log($"Top already present");
                    }
                    // If Pie has base & filling
                    if (pie.pbase != "Default" && pie.filling != "Default")
                    {
                        pie.top = ingredient.name;
                        Debug.Log($"New Top : {pie.top}");
                    }
                    else
                    {
                        Debug.Log("Add a base and filling first");
                    }
                    break;
            }
        }
    // If pie is complete, returns true
    public bool PieCompleted()
    {
        if(pie.pbase != "Default" && pie.filling != "Default" && pie.top != "Default")
        {
            return true;
        }
        else { return false; }
    }
    }
