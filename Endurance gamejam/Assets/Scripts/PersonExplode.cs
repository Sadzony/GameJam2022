using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonExplode : MonoBehaviour
{
    private Rigidbody rb;
    private Rigidbody[] childRbs;
    [HideInInspector] public bool exploded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        childRbs = GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody childRB in childRbs)
        {
            childRB.constraints = RigidbodyConstraints.FreezePosition;
        }
    }

    public void Explode()
    {
        if (!exploded)
        {
            Debug.Log("Died");
            transform.parent = transform.parent.parent.parent;
            foreach (Rigidbody childRB in childRbs)
            {
                childRB.constraints = RigidbodyConstraints.None;
                childRB.velocity = rb.velocity;
            }
            exploded = true;
        }
    }
}
