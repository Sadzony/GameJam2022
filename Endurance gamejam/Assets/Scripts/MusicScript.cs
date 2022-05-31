using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            if (GameObject.Find("Player"))
            {
                player = GameObject.Find("Player").transform;
            }
        }
        else
        {
            transform.position = player.position;
        }
    }
}
