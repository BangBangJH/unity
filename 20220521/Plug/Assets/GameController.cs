using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public SceneManagerController SceneMan;
    public PlugController Pctr;
    private float timer_Jump;
    private float max_Jump = 0.5f;
    private bool spaceDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void FixedUpdate()
    {
        MoveInput();
        //TurnInput();
        SpaceInput();
        EnterInput();
        MouseInput();
        ReStartInput();
        EscInput();
    }

    void MoveInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Pctr.Move_Forward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            Pctr.Move_Back();
        }
        if (Input.GetKey(KeyCode.A))
        {
            Pctr.Move_Left();
        }
        if (Input.GetKey(KeyCode.D))
        {
            Pctr.Move_Right();
        }
    }
    void TurnInput()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Pctr.Turn_CCW();
        }
        if (Input.GetKey(KeyCode.E))
        {
            Pctr.Turn_CW();
        }
    }
    void SpaceInput()
    {
        if (!spaceDown &&Input.GetKeyDown(KeyCode.Space))
        {
            timer_Jump = Time.time;
            if (Pctr.Jump_Min())
            {
                spaceDown = true;
            }
        }
        if (spaceDown && Input.GetKey(KeyCode.Space))
        {
            if(Mathf.Abs(timer_Jump - Time.time) >= max_Jump)
            {
                Pctr.Jump(max_Jump);
                timer_Jump = 0;
                spaceDown = false;
            }

        }
        if (spaceDown && Input.GetKeyUp(KeyCode.Space))
        {
            float jump = Time.time - timer_Jump;
            Pctr.Jump(jump);
            spaceDown = false;
            timer_Jump = 0;
        }
    }
    void MouseInput()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Pctr.MouseRightClick();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Pctr.MouseLeftClick();
        }
    }


    void EnterInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Pctr.Enter();
        }
        
    }

    void ReStartInput()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneMan.ReStartStage();
        }
    }
    void EscInput()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneMan.Setting();
        }
    }
}
