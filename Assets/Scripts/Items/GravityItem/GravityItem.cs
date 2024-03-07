using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityItem : Item
{

    public Collider gravityCollider;
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
        StartCoroutine(Disable(0.2f));
    }
    private IEnumerator Disable(float time)
    {
        yield return new WaitForSeconds(time);

        this.gameObject.SetActive(false);
    }
}
