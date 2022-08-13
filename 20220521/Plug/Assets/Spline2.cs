using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spline2 : MonoBehaviour
{
    public GameObject forward;
    public GameObject back;
    public bool max = false;
    public bool max_forward = false;

    private float lenth;
    public float force;
    private float force_limit;
    private float force_limit_neag;

    private Vector3 movePos;
    // Start is called before the first frame update
    void Start()
    {
        lenth = (forward.transform.position - back.transform.position).magnitude;
        movePos = (forward.transform.position + back.transform.position) / 2;
        //lenth_Center = lenth / centerNum;
    }

    // Update is called once per frame
    void Update()
    {
        //if (max_forward == false)
        //{
        //    Spline();
        //}

    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePos, 10f);
    }

    public bool Spline()
    {
         float moveVertical;
         float moveHorizontal;
        moveVertical = (forward.transform.position - back.transform.position).magnitude;
        Mathf.Abs(moveVertical);
        if (moveVertical > lenth)
        {
            moveVertical = lenth;
            moveHorizontal = 0;
        }
        else
        {
            moveHorizontal = Mathf.Sqrt(Mathf.Pow(lenth / 2, 2f) - Mathf.Pow(moveVertical / 2, 2f));
        }
        //moveHorizontal = Mathf.Sqrt(Mathf.Abs( Mathf.Pow(lenth / 2, 2f) - Mathf.Pow(moveVertical / 2, 2f)));

        movePos = (forward.transform.position + back.transform.position)/2;
        movePos.x += moveHorizontal;
        //¿Ã∞≈Debug.LogFormat("Lenth : {0} moveVertical : {1} moveHorizontal : {2} obj : {3}", lenth, moveVertical, moveHorizontal,gameObject);
        if (moveVertical == lenth || moveHorizontal == 0)
        {
            max = true;
            //back.GetComponent<Spline2>().GetForce(max);
        }
        else
        {
            max = false;
            //back.GetComponent<Spline2>().GetForce(max);
        }

        return !max;
        //Debug.Log(lenth);
        //Debug.Log("moveVertical : ");
        //Debug.Log(moveVertical);
        //Debug.Log(moveHorizontal);

    }
    public void GetForce(bool f)
    {
        max_forward = f;
      
    }
}
