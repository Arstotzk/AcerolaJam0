using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenItem : MonoBehaviour
{
    public Item item;
    public Vector3 pickTransform;

    public void SetItem(Item _item)
    {
        item = _item;
        item.PickUp();
        item.transform.SetParent(this.transform);
        item.transform.localPosition = item.positionOnPick;
        item.transform.rotation = this.transform.rotation;
        item.transform.Rotate(item.rotate);
        var regidbody = item.GetComponent<Rigidbody>();
        regidbody.isKinematic = true;
    }

}
