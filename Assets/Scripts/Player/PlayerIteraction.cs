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
                    //TODO item -> iteractItem; pickableItem
                    var item = hit.transform.gameObject.GetComponent<Item>();
                    if (item != null)
                    {
                        inventory.PickUpItem(item);
                    }
                    var door = hit.transform.gameObject.GetComponent<Door>();
                    if (door != null)
                    {
                        door.Action();
                    }
                    var switchObject = hit.transform.gameObject.GetComponent<Switch>();
                    if (switchObject != null)
                    {
                        switchObject.Action();
                    }
                }
            }
        }

        if (Input.GetButtonDown("Drop"))
        {
            var item = inventory.GetChosenItem();
            if (item != null)
            {
                item.Drop();
                inventory.RemoveItem(item);
            }
        }

        if (Input.GetButtonDown("RightClick"))
        {
            var item = inventory.GetChosenItem();
            if (item != null)
            {
                item.IteractionRightClickDown();
            }
        }
        if (Input.GetButton("RightClick"))
        {
            var item = inventory.GetChosenItem();
            if (item != null)
            {
                item.IteractionRightClickHold();
            }
        }
        if (Input.GetButtonUp("RightClick"))
        {
            var item = inventory.GetChosenItem();
            if (item != null)
            {
                item.IteractionRightClickUp();
                inventory.RemoveItem(item);
            }
        }

        if (Input.GetButtonDown("LeftClick"))
        {
            var item = inventory.GetChosenItem();
            if (item != null)
            {
                item.IteractionLeftClickDown();
            }
        }
        if (Input.GetButton("LeftClick"))
        {
            var item = inventory.GetChosenItem();
            if (item != null)
            {
                item.IteractionLeftClickHold();
            }
        }
        if (Input.GetButtonUp("LeftClick"))
        {
            var item = inventory.GetChosenItem();
            if (item != null)
            {
                item.IteractionLeftClickUp();
            }
        }
    }
}
