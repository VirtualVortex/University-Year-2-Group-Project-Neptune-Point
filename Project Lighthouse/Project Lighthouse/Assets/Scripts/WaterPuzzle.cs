using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPuzzle : MonoBehaviour
{
    [SerializeField]
    private Manager mm;
    [SerializeField]
    private string scene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Correct");
            mm.EndPuzzle(scene);
        }
    }
}
