using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacoHover : MonoBehaviour
{
    public bool hovering = true;

    Vector3 hoverPos;

    float currentElevation;

    float hoverTransitionSpeed = 3f;

    float returnHoverTimer = 6f;


    // Start is called before the first frame update
    void Start()
    {
        hoverPos = transform.position;

        currentElevation = hoverPos.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (hovering)
        {
            currentElevation = Mathf.Lerp(currentElevation, hoverPos.y + Mathf.Sin(Time.realtimeSinceStartup)*.2f, hoverTransitionSpeed * Time.deltaTime);

        }
        else {
            currentElevation = Mathf.Lerp(currentElevation, hoverPos.y-20, (hoverTransitionSpeed/8) * Time.deltaTime);

            returnHoverTimer -= Time.deltaTime;

            if (returnHoverTimer < 0)
            {
                hovering = true;
                returnHoverTimer = 6f;
            }

        }


        transform.position = new Vector3(hoverPos.x, currentElevation, hoverPos.z);
    }
}
