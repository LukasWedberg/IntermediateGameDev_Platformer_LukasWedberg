using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class GameManager : MonoBehaviour
{
    float timeAllowed = 180f;

    [SerializeField]
    TMP_Text timeRemainingUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Altering the timer
        if (timeAllowed > 0f)
        {
            timeAllowed -= Time.deltaTime;

            string extraZero = "";

            if ( (Mathf.Round(timeAllowed) % 60)/10 < 1)
            {
                extraZero = "0";
            }

            timeRemainingUI.text = (Mathf.Ceil(timeAllowed/60)-1).ToString() +" : "+ extraZero + (Mathf.Round(timeAllowed)%60).ToString();

        }



        //Player energy depletion



    }
}
