using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityItem : Item
{

    public Collider gravityCollider;
    public GameObject vfx;
    override protected void Start()
    {
        base.Start();
    }
    void Update()
    {
        
    }
    public void ChangeGravity()
    {
        gravityCollider.enabled = true;
        GetComponent<MeshRenderer>().enabled = false;
        vfx.SetActive(true);
        StartCoroutine(Disable(1f));
    }
    private IEnumerator Disable(float time)
    {
        yield return new WaitForSeconds(time);

        this.gameObject.SetActive(false);
    }
}
