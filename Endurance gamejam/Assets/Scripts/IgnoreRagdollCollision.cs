using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreRagdollCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(9, 9);
    }
}
