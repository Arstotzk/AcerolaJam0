using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerNarrow : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isNarrow = false;
    public Narrow narrow;
    public GameObject itemsUI;
    public GameObject hintUI;
    public float maxDistance = 100f;
    public Volume volume;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNarrow)
        {
            var heading = narrow.transform.position - this.transform.position;
            Debug.Log("PlayerNarrow: " + heading.sqrMagnitude);
            float size = 1f - heading.sqrMagnitude/maxDistance;
            if (size < 0.1f)
                size = 0.1f;
            volume.weight = 1 - size;
            Vector3 vectorScale = new Vector3(size, size, size);
            itemsUI.transform.localScale = vectorScale;
            hintUI.transform.localScale = vectorScale;

        }
    }
}
