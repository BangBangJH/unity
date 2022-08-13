using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blub : MonoBehaviour
{
    [Range(0, 10)]
    public float value = 0f;
    public bool lightBool = false;
    private Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        Lighting();
    }
    
    public void PlugOut()
    {
        StopAllCoroutines();
        StartCoroutine(RemainPower());
        IEnumerator RemainPower()
        {
            yield return new WaitForSeconds(3f);
            StartCoroutine(LightOff());
        }
    }

    public void Interact()
    {
        if(lightBool == true)
        {
            TurnOff();
        }
        else if (lightBool == false)
        {
            TurnOn();
        }
    }

    private void TurnOn()
    {
        
        var b = StartCoroutine(LightOn());
    }

    private void TurnOff()
    {
        StopAllCoroutines();
        StartCoroutine(LightOff());
    }

    private void Lighting()
    {
        light.intensity = value - 1 + (Mathf.Sin(32 * Time.realtimeSinceStartup) / 10);
    }

    IEnumerator LightOn()
    {   
        yield return null;
        Debug.Log("lightOn 1");
        lightBool = true;
        //for(int i=0; i < 100;i++)
        //{
        //    value += 0.1f;
        //    yield return null;
        //    Debug.Log("on");
        //}
        while(value < 10)
        {
            value += 10 * Time.deltaTime ;
            yield return null;
        }
        //StartCoroutine(lighting());
        //value = 10 * Time.deltaTime;
        //yield return new WaitForSeconds(1f);
    }

    IEnumerator LightOff()
    {
        yield return null;
        Debug.Log("lightOff 1");
        lightBool = false;
        float f = 0f;
        while(value>0)
        {
            f += Time.deltaTime;
            value = Mathf.Lerp(10, 0,f);
            yield return null;
        }
        
        //yield return new WaitForSeconds(1f);
    }
}
