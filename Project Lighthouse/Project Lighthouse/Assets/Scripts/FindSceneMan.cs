using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSceneMan : MonoBehaviour
{
    PersistantSceneManager PScene_Man;

    // Start is called before the first frame update
    void Start()
    {
        PScene_Man = GameObject.Find("PSceneMan").GetComponent<PersistantSceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoFungusChange() 
    {
        PScene_Man.FungusChangeScene();
    }
}
