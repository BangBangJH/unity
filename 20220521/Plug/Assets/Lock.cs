using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public lockdoor lockdoorObj;
    float value;
    float max_Value = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
   

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Key"))
        {
            Debug.Log("col1");
            value = 0;
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Key"))
        {
            Debug.Log("col");
            value += Time.deltaTime;
            if (value >= max_Value)
            {
                OpenDoor();
            }
        }
    }

    ////void RayKey()
    //{
     
    //    if (Physics.BoxCast(transform.position,new Vector3(),Vector3.up, out RaycastHit hit))
    //    {

    //    }
    //}

    void OpenDoor()
    {
        Debug.Log("open");
        lockdoorObj.KeyOpen();
    }

}
