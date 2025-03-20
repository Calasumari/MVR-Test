using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalScreen : MonoBehaviour
{

    [SerializeField] TextMeshPro timeTextIG;
    [SerializeField] TextMeshPro timeTextFinal;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject restart;

    public float timer = 0;

    //unfortunately does not account for the 
    int countdown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            if (countdown >= 180)
            {
                Debug.Log("Hit finish line");
            }
            else
            {
                countdown += 1;
                Debug.Log(countdown);
            }
            
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other == "Finish") { }
    }*/
}
