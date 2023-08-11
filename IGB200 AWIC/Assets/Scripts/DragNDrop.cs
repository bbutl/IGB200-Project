using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour 
{
    static public GameObject draggedObject;
    

    private Vector3 mousePosOffset;
    private bool isClicked = false;
    private GameObject duplicateObject;
    private Transform parentAfterDrag;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private Vector3 GetMouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public void OnMouseDown()
    {
        duplicateObject = this.gameObject;
        mousePosOffset = gameObject.transform.position - GetMouseWorldPos();
        Instantiate(duplicateObject, GetMouseWorldPos() + mousePosOffset, Quaternion.identity);
        
    }
    public void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mousePosOffset;
    }
    
    public void OnMouseUp()
    {
        
        Destroy(gameObject);

    }
    


}
