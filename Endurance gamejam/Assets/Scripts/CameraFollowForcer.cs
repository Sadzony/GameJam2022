using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowForcer : MonoBehaviour
{
    public Transform follow;
    private Cinemachine.CinemachineVirtualCamera virtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GetComponentInChildren<Cinemachine.CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        virtualCamera.Follow = follow;

        transform.Translate(follow.position);
    }
}
