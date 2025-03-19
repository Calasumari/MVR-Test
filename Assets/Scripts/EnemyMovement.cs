using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.EventSystems;

public class EnemyMovement : MonoBehaviour
{
    public Collision collision;

    public bool isTouching(Collision collision)
    {
        if (collision.gameObject.name == "Powerboat")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Collision Detected");
            return true;
        }
        else
        {
            return false;
        }
    }

  

    private void Update()
    {
        isTouching(collision);
    }








}
