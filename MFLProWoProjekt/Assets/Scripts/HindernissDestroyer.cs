using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HindernissDestroyer : MonoBehaviour
{
    void Update()
    {
        if (GameManager.instance.player != null)
        {
            if (gameObject.transform.position.x <= GameManager.instance.player.transform.position.x - 120)
            {
                Destroy(gameObject);
            }
        }

    }
}
