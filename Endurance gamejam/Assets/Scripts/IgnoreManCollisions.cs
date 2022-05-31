using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreManCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(7, 8);
    }

}
