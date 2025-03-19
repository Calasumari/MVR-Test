using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textMesh;

    string playTime;
    float timeNum = 0;

    void Start()
    {
        textMesh.text = playTime;
    }

    // Update is called once per frame
    void Update()
    {
        updateTime();
    }

    void updateTime()
    {   
        timeNum = timeNum + Time.deltaTime;
        Debug.Log(timeNum);
        playTime = timeNum.ToString();
    }
}
