using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider damageCollider;
    public Collider fearCollider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOnColliders()
    {
        damageCollider.enabled = true;
        fearCollider.enabled = true;
        StartCoroutine(Disable(0.2f));
    }

    private IEnumerator Disable(float time)
    {
        yield return new WaitForSeconds(time);

        damageCollider.enabled = false;
        fearCollider.enabled = false;
        this.gameObject.SetActive(false);
    }
}
