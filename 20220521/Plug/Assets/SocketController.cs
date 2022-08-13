using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketController : MonoBehaviour
{

    private enum Name { socket, light, f};
    [SerializeField]
    private Name name = Name.socket;
    public GameObject addObj;
    private string socketName;
    public Transform socketCenter;
    public PlugController plugCtr;
    public SceneManagerController sceneMan;
    public string NextStageName;
    private Rigidbody rb;

    public bool stageSocket = false;
    public bool plug = false;
    private float magnetForce = 0.7f;
    private float socket_R = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        socketName = name.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PlugIn();
    }

    public void PlugIn()
    {
        if(!plug && (socketCenter.position - plugCtr.plugCenter.position).magnitude < magnetForce)
        {
            Debug.Log("plug");
            plugCtr.connection = true;
            plugCtr.obj_R = socket_R;
            plugCtr.PlugIn(gameObject);
            plug = true;
            rb.isKinematic = true;
            if(stageSocket)
            {
                NextStage();
            }

        }
    }
    public void PlugedIn()
    {
  
        
    }
    public void PlugOut()
    {
        PlugOut_Addobj();
        transform.Translate(Vector3.forward*2);
        transform.parent = null;
        plug = false;
        rb.isKinematic = false;
        //gameObject.GetComponent<BoxCollider>().enabled = true;

    }
    public void NextStage()
    {
        sceneMan.NextStage(NextStageName);
    }
    public void Interact()
    {
        if(socketName == "light")
        {
            addObj.GetComponent<blub>().Interact();
        }
    }
    
    public void PlugOut_Addobj()
    {
        if (socketName == "light")
        {
            addObj.GetComponent<blub>().PlugOut();
        }
    }
}