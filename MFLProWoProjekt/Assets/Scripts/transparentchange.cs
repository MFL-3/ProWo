using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transparentchange : MonoBehaviour
{
    private Renderer ren;
    // Start is called before the first frame update
    void Start()
    {
        ren = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.z <= GameManager3d.instance.player3d.transform.position.z + 10)
        {
            ren.material.color = new Color(ren.material.color.r, ren.material.color.g, ren.material.color.b, 0.1f);
        }
    }
}
