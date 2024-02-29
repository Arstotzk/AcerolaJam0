using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIteraction : MonoBehaviour
{
    public Inventory inventory;
    public float iteractDistance = 1.5f;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Interaction"))
        {
            Camera camera = Camera.main;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] raycastHits = Physics.RaycastAll(ray);
            foreach (var hit in raycastHits)
            {
                Debug.Log("Raycast object: " + hit.transform.name + " distance: " + hit.distance);
                if (hit.distance < iteractDistance)
                {
                    var item = hit.transform.gameObject.GetComponent<Item>();
                    if (item != null)
                    {
                        inventory.PickUpItem(item);
                    }
                }
            }
        }
    }
}
