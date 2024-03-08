using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Item : MonoBehaviour
{
    public Collider itemCollider;
    public MeshCollider itemMeshCollider;
    public Collider triggerCollider;
    public Vector3 positionOnPick;
    public Vector3 rotate;
    public GameObject ground;

    public LineRenderer lineRenderer;
    public int linePoints = 20;
    public float timeBetweenPoints = 0.1f;
    public float throwForce = 10f;

    virtual protected void Start()
    {
        var player = GameObject.FindGameObjectsWithTag("Player").FirstOrDefault();
        lineRenderer = player.GetComponent<LineRenderer>();
        ground = GameObject.FindGameObjectsWithTag("MainGround").FirstOrDefault();
    }

    void Update()
    {

    }

    public void PickUp()
    {
        if (itemCollider != null)
            itemCollider.enabled = false;
        if (itemMeshCollider != null)
            itemMeshCollider.enabled = false;
        triggerCollider.enabled = false;
    }
    virtual public void IteractionRightClickDown()
    {

    }
    virtual public void IteractionRightClickHold(bool isReverseGravity)
    {
        lineRenderer.enabled = true;
        lineRenderer.positionCount = Mathf.CeilToInt(linePoints / timeBetweenPoints) + 1;
        Vector3 startPosition = transform.position;
        Vector3 startVelocity = Camera.main.transform.forward * throwForce / GetComponent<Rigidbody>().mass;
        int index = 0;
        lineRenderer.SetPosition(index, startPosition);
        for (float time = 0f; time < linePoints; time += timeBetweenPoints)
        {
            index++;
            Vector3 point = startPosition + time * startVelocity;
            var reverseGravity = 1f;
            if (isReverseGravity)
                reverseGravity = -1f;
            point.y = startPosition.y + startVelocity.y * time + (Physics.gravity.y * reverseGravity / 2f * time * time);
            lineRenderer.SetPosition(index, point);
        }
    }
    virtual public void IteractionRightClickUp()
    {
        Unset();
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(Camera.main.transform.forward * throwForce, ForceMode.Impulse);
    }
    virtual public void IteractionLeftClickDown()
    {

    }
    virtual public void IteractionLeftClickHold()
    {

    }
    virtual public void IteractionLeftClickUp()
    {

    }
    public void Drop()
    {
        Unset();
    }

    private void Unset()
    {
        lineRenderer.enabled = false;
        transform.parent = ground.transform;
        if(itemCollider != null)
            itemCollider.enabled = true;
        if (itemMeshCollider != null)
            itemMeshCollider.enabled = true;
        triggerCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
