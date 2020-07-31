using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dial_Script : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool tracing;           // whether or not the mouse is down on this particular dial
    float angleRad;         // angle in radians which the dial is currently turned out 
    RectTransform myRect;   // this objects Rect Transform
    Vector2 lookingAt;   //  used for the direction 
    public float lookingAtAngle;
    [SerializeField] Sprite[] possibleDials;




    void Start()
    {
        GetComponent<Image>().sprite = possibleDials[Random.Range(0,possibleDials.Length-1)];
        angleRad = 0 * Mathf.Deg2Rad;
        myRect = GetComponent<RectTransform>();
        lookingAt = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f)).normalized;     // random starting direction
        myRect.right = lookingAt;
        lookingAtAngle = Mathf.Atan2(lookingAt.y,lookingAt.x) * Mathf.Rad2Deg;
    }

    void Update()
    {
        if (tracing)
        {
            Vector2 thingy = Input.mousePosition - myRect.position;
            lookingAt = new Vector2(((thingy.x * Mathf.Cos(angleRad)) - (thingy.y * Mathf.Sin(angleRad))),((thingy.x * Mathf.Sin(angleRad)) + (thingy.y * Mathf.Cos(angleRad)))).normalized; // probs not the most efficient way
            myRect.right = lookingAt;
            lookingAtAngle = Mathf.Atan2(lookingAt.y,lookingAt.x) * Mathf.Rad2Deg;
        }
    }
    
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        float rot1 = myRect.eulerAngles.z;
        float rot2 = Mathf.Atan2(eventData.position.y-transform.position.y, eventData.position.x - transform.position.x) * Mathf.Rad2Deg;
        angleRad = (rot1 - rot2) * Mathf.Deg2Rad;
        tracing = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        tracing = false;
    }
}
