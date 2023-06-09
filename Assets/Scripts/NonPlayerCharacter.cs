using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    [SerializeField] float displayTime = 4.0f;
    [SerializeField] GameObject dialogBox;
    float timeDisplayed;


    
    void Start()
    {
        dialogBox.SetActive(false);
        timeDisplayed = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeDisplayed >= 0.0f)
        {
            timeDisplayed -= Time.deltaTime;
            
            if (timeDisplayed < 0.0f)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    public void DisplayDialog()
    {
        dialogBox.SetActive(true);
        timeDisplayed = displayTime;
    }
}
