using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    int page = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (page==6)
        {
            page = 1;
        }
        if (page == 0)
        {
            page = 5;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            page = page - 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            page = page + 1;
        }

        if(page == 1)
        {
            p1.SetActive(true);
            p2.SetActive(false);
            p3.SetActive(false);
            p4.SetActive(false);
            p5.SetActive(false);
        }
        if (page == 2)
        {
            p1.SetActive(false);
            p2.SetActive(true);
            p3.SetActive(false);
            p4.SetActive(false);
            p5.SetActive(false);
        }
        if (page == 3)
        {
            p1.SetActive(false);
            p2.SetActive(false);
            p3.SetActive(true);
            p4.SetActive(false);
            p5.SetActive(false);
        }
        if (page == 4)
        {
            p1.SetActive(false);
            p2.SetActive(false);
            p3.SetActive(false);
            p4.SetActive(true);
            p5.SetActive(false);
        }
        if (page == 5)
        {
            p1.SetActive(false);
            p2.SetActive(false);
            p3.SetActive(false);
            p4.SetActive(false);
            p5.SetActive(true);
        }

    }
}
