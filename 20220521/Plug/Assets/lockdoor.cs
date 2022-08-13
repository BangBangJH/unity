using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockdoor : MonoBehaviour
{
    public Transform openPos;
    public Vector3 closePos;
    public bool doorSwitch = false;
    public bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        closePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorSwitch)
        {
            if (open)
            {
                OpenDoor();
            }
            else if (!open)
            {
                
                CloseDoor();
            }
        }
    }

    public void OpenDoor()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, openPos.position, 2 * Time.deltaTime);
    }
    public void CloseDoor()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, closePos, 2 * Time.deltaTime);
    }
}
