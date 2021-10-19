using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex02 : MonoBehaviour
{
    [SerializeField]private float secHello = 4;
    [SerializeField]private float secUp = 1;
    [SerializeField]private float setStopHello = 30;

    private Coroutine printHello;


    private IEnumerator BeingPressed()
    {
        WaitForPress wfp = new WaitForPress();
        while(true)
        {
            yield return wfp;
            Debug.Log("Estou a ser pressionado!");
        }
    }

    private IEnumerator PrintHello(float secs)
    {
        WaitForSeconds wfs = new WaitForSeconds(secs);
        while (true)
        {
            Debug.Log("Hello");
            yield return wfs;
        }
    }

    private IEnumerator CountUp(float secs, float secsStopHello)
    {
        int count = 0;
        WaitForSeconds wfs = new WaitForSeconds(secs);

        while (true)
        {
            Debug.Log($"{count}");
            count ++;

            if (count == secsStopHello)
            {
                StopCoroutine(printHello);
            }

            yield return wfs;
        }
    }

    private void Start()
    {
        printHello = StartCoroutine(PrintHello(secHello));
        StartCoroutine(CountUp(secUp,setStopHello));
        StartCoroutine(BeingPressed());
    }

    
    private void Update()
    {
        
    }
}
