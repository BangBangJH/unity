using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockdoor : MonoBehaviour
{
    public Transform openPos;
    public Vector3 closePos;
    public bool doorSwitch = false;
    public bool open = false;
    public GameObject light1;
    public GameObject light2;
    float value = 0;
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

    public void KeyOpen()
    {
        doorSwitch = true;
        open = true;
    }
    public void OpenDoor()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, openPos.position, 2 * Time.deltaTime);
        StartCoroutine(DoorLight());
        
    }
    public void CloseDoor()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, closePos, 2 * Time.deltaTime);
    }
    IEnumerator DoorLight()
    {
        while (value < 600)
        {
            value += 100 * Time.deltaTime;
            light1.GetComponent<Light>().intensity = value;
            yield return null;
        }
        yield return new WaitForSeconds(4f);
        light2.SetActive(true);
    }
    void SlowLight()
    {
      
        
    }
}
