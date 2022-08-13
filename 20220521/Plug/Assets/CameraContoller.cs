using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    public GameObject plug;
    private Vector3 pos;
    private float cameraSpeed = 0.3f;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position - plug.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, plug.transform.position + pos, ref velocity, cameraSpeed * Time.deltaTime);
    }
}
