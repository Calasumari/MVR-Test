using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalScreen : MonoBehaviour
{
    [SerializeField] GameObject restart;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject bg;
    [SerializeField] GameObject timerText;
    [SerializeField] GameObject finalScore;

    public float timer = 0;

    //unfortunately does not account for the 
    int countdown;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        restart.SetActive(false);
        bg.SetActive(false);
        timerText.SetActive(true);
        finalScore.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Finish")
        {
            /*if (countdown >= 180)
            {
                Debug.Log("Hit finish line");
                retryScreen();
            }
            else
            {
                countdown += 1;
                Debug.Log(countdown);
            }*/
            retryScreen();
            
        }
    }

    void retryScreen()
    {
        canvas.SetActive (true);
        restart.SetActive(true);
        bg.SetActive (true);
        timerText.SetActive (false);
        //finalScore.SetActive (true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

}
