using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveOfGame : MonoBehaviour
{
    public Text objectiveOfGame; 

    private void Start()
    {
        Invoke("DisableText", 5f);//invoke after 5 seconds
    }

    void DisableText()
    {
        objectiveOfGame.enabled = false;
    }
}
