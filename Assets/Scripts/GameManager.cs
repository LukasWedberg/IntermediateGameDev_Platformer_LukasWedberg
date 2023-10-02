using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GameManager : MonoBehaviour
{
    float timeAllowed = 180f;

    [SerializeField]
    TMP_Text timeRemainingUI;

    [SerializeField]
    Transform sleepometerPointer;




    float playerEnergy = 100f;

    public float currentPlayerEnergy;

    float pointerStartAngle = 0f;

    float pointerEndAngle = -180f;

    public float tacoBonusEnergy;



    bool napTime = false;

    [SerializeField]
    Image screenShroud;

    float shroudAlpha = 0;

    float shroudFadeSpeed = 1f;

    float napTimer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerEnergy = playerEnergy;

        tacoBonusEnergy = playerEnergy/3;
    }

    // Update is called once per frame
    void Update()
    {

        if (napTime)
        {
            shroudAlpha = Mathf.Lerp(shroudAlpha, 1, shroudFadeSpeed * Time.deltaTime);

            napTimer -= Time.deltaTime;

            if (napTimer < 0) {
                napTime = false;
                napTimer = 3f;

                currentPlayerEnergy = playerEnergy;

                //Edit timer here!
                timeAllowed -= Random.Range(5f,15f);
            }
        }
        else
        {

            shroudAlpha = Mathf.Lerp(shroudAlpha, 0, shroudFadeSpeed * Time.deltaTime);




            //Altering the timer
            if (timeAllowed > 0f)
            {
                timeAllowed -= Time.deltaTime;

                string extraZero = "";

                if ((Mathf.Round(timeAllowed) % 60) / 10 < 1)
                {
                    extraZero = "0";
                }

                timeRemainingUI.text = (Mathf.Ceil(timeAllowed / 60) - 1).ToString() + " : " + extraZero + (Mathf.Round(timeAllowed) % 60).ToString();

            }



            //Player energy depletion
            if (currentPlayerEnergy > 0f)
            {
                currentPlayerEnergy = Mathf.Min(currentPlayerEnergy, playerEnergy);

                currentPlayerEnergy -= Time.deltaTime;

                sleepometerPointer.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(pointerEndAngle, pointerStartAngle, currentPlayerEnergy / playerEnergy));
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                napTime = true;
            }


        }

        screenShroud.color = new Color(0.09803921568f, 0.15686274509f, 0.20784313725f, shroudAlpha);

    }
}
