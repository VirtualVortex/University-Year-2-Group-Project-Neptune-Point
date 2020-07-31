using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionTracker : MonoBehaviour
{
    [SerializeField, Tooltip("It works best, when the number is small e.g. 0.7")]
    float delay;

    bool inDanger;
    float timer;
    PlayerMovementV2 pm;
    List<Vector2> postionList = new List<Vector2>();
    List<Vector2> anxPostionList = new List<Vector2>();
    GameObject foundObject;

    // Start is called before the first frame update
    void Start()
    {
        inDanger = false;
        pm = GetComponent<PlayerMovementV2>();
        foundObject = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {

        if (!pm.inAir)
            inDanger = false;

        if (pm.inAir)
            inDanger = true;

        //Set playerPos to the player's position every set amount of time 
        //and if player isn't in the air

        if (!inDanger)
        {

            if (Time.time > timer)
            {
                timer = Time.time + delay;
                SetPosition();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.transform.CompareTag("Untagged"))
        {
            inDanger = false;
            SetPosition();
        }*/

        if (collision.transform.CompareTag("Danger") || foundObject.transform.Find("Slider").GetComponent<Slider>().value == 1.0f)
        {
            Debug.Log(Vector2.Distance(collision.transform.position, postionList[postionList.Count - 1]));

            if (Vector2.Distance(collision.transform.position, postionList[postionList.Count - 1]) < 6.75f)
            {
                GetPreviousPosition();
            }
            else if (Vector2.Distance(collision.transform.position, postionList[postionList.Count - 1]) > 6.75f)
            {
                GetPosition();
            }

        }

        if (collision.transform.name.Contains("Anxiety"))
            SetPosition();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Untagged"))
        {
            inDanger = false;
            SetPosition();
        }
    }

    //Set playerPos to the player's position
    void SetPosition()
    {
        postionList.Add(transform.position);
        anxPostionList.Add(transform.position);
        //Debug.Log(postionList.Count);
    }

    //Set the player's position to the value from playerPos
    void GetPosition()
    {
        transform.position = postionList[postionList.Count - 1];
        postionList.Clear();
        inDanger = true;
    }

    void GetPreviousPosition()
    {
        transform.position = postionList[postionList.Count - 4];
        postionList.Clear();
        inDanger = true;
    }

    public void GetAnxietyPosition()
    {
        transform.position = anxPostionList[0];
        anxPostionList.Clear();
        inDanger = true;
    }
}
