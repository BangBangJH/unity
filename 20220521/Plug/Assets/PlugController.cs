using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugController : MonoBehaviour
{
    Rigidbody rb;
    RaycastHit hit;
    private float F_obj_R = 0.5f;
    public float obj_R = 0.5f;
    private float turnSpeed = 100f;
    public bool connection = false;
    private bool theAir = false;
    public Transform plugCenter;
    public Camera cam;
    private GameObject connectionObj;

    public Spline2 spl;
    public Spline2 spl2;
    public Spline2 spl3;
    public Spline2 spl4;

    public Spline2[] spls;
    public Vector3 force;

    RaycastHit mHit;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        MouseRay();
    }
    void FixedUpdate()
    {
        //Max();
        SplineStart();
    }

    private void MouseRay()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out mHit))
        {
            //transform.LookAt(mHit.point);
            Quaternion look = Quaternion.LookRotation(mHit.point - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, look, 2*Time.deltaTime);
        }
    }

    public void PlugIn(GameObject obj)
    {
        if (connection)
        {
            //obj.GetComponent<BoxCollider>().enabled = false;
            rb.velocity = Vector3.zero;
            transform.rotation = Quaternion.Euler(obj.transform.rotation.eulerAngles);
            
            connectionObj = obj;
            transform.position += obj.GetComponent<SocketController>().socketCenter.position - plugCenter.position;
            obj.transform.SetParent(transform);
        }
    }
    public void PlugOut()
    {
        if (connection)
        {
            connectionObj.GetComponent<SocketController>().PlugOut();
            connectionObj = null;
            obj_R = F_obj_R;
            connection = false;
        }
    }
    public void Interact()
    {
        if (connection)
        {
            connectionObj.GetComponent<SocketController>().Interact();
        }
    }

    void SplineStart()
    {
        for (int i = 0; i < spls.Length; i++)
        {

            if (spls[i].Spline())
                break;
            
        }
    }
    public void Move_Forward()
    {
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(90, 0, 0), turnSpeed * Time.deltaTime);
        rb.AddForce(0, 0, 10);
        force += rb.velocity;
    }
    public void Move_Back()
    {
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(90, 0, 0), turnSpeed * Time.deltaTime);
        rb.AddForce(0, 0, -10);
        force += rb.velocity;
    }
    public void Move_Right()
    {
        rb.AddForce(10, 0, 0);
        force += rb.velocity;
    }
    public void Move_Left()
    {
        rb.AddForce(-10, 0, 0);
        force += rb.velocity;
    }
    public void Turn_CCW()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(90, 0, 90), turnSpeed * Time.deltaTime);
    }
    public void Turn_CW()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(90, 0, -90), turnSpeed * Time.deltaTime);
    }
    public void MouseRightClick()
    {
        PlugOut();
    }
    public void MouseLeftClick()
    {
        Interact();
    }

    public void Space(float t)
    {

        

    }
    public bool Jump_Min()
    {
        if (Mathf.Abs(rb.velocity.y) <= 0.2f)
        {
            Debug.Log("min2");
            rb.AddForce(0, 10, 0, ForceMode.Impulse);
            return true;
        }
       
        return false;
      
    }
    public void Jump(float t)
    {
        Debug.Log(t);
        rb.AddForce(0, 12 * t, 0, ForceMode.Impulse);


    }

    public void Enter()
    {
        Debug.Log("Enter");
    }

    
}
