using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Script : MonoBehaviour
{

    Owl_dialPositions theDialPositions;
    Owl_Manager owl_Man;
    public float sumAngles = 0.1f;
    [SerializeField, Range(0f,750)] float radius = 150;
    public RectTransform myR;
    Canvas myC;
    dialSensitivity dialSens;
    [SerializeField] RectTransform theSun;
    [SerializeField] bool debugDials = false;
    float scale;


    // Start is called before the first frame update
    void Start()
    {
        owl_Man = FindObjectOfType<Owl_Manager>();
        myR = GetComponent<RectTransform>();
        //myR.SetAsFirstSibling();
        //StartCoroutine("LayerCheckBot");
        dialSens =new dialSensitivity(Random.Range(0,3), Random.Range(0,3), Random.Range(0,3));
        myC = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        scale = (float)Screen.width / (float)1600;
        myR.localScale = new Vector3(scale, scale, 1);

        theDialPositions = owl_Man.theDialPositions;

        sumAngles = (theDialPositions.SumSens(dialSens.Sens1, dialSens.Sens2, dialSens.Sens3) + 90 + Win_Check.winDirection) * Mathf.Deg2Rad;
        //sumAngles+=0.01f;

        myR.transform.position = new Vector3(
                        (radius * scale) * (Mathf.Sin(sumAngles)) / 1 + owl_Man.GetComponent<RectTransform>().position.x,
                        (radius * scale) * (Mathf.Cos(sumAngles)) / 3 + owl_Man.GetComponent<RectTransform>().position.y,
                        -1 );

        if (debugDials)
        {
            Debug.LogError(Mathf.Cos(sumAngles));
        }
        myC.sortingOrder = (int)(-Mathf.Cos(sumAngles)*radius);
        
    }

    // IEnumerator LayerCheckTop()
    // {
    //     yield return new WaitUntil(() => Mathf.Cos(sumAngles) < 0 );
    //     myR.SetAsFirstSibling();
    //     if (debugDials) Debug.LogError("TOP");
    //     StartCoroutine("LayerCheckBot");
    // }

    // IEnumerator LayerCheckBot()
    // {
    //     yield return new WaitUntil(() => Mathf.Cos(sumAngles) > 0 );
    //     myR.SetAsLastSibling();
    //     if (debugDials) Debug.LogError("BOT");
    //     StartCoroutine("LayerCheckTop");
    // }
}

struct dialSensitivity
{
    public dialSensitivity(int sens1, int sens2, int sens3)
    {
        Sens1 = sens1;
        Sens2 = sens2;
        Sens3 = sens3;
    }

    public int Sens1;
    public int Sens2;
    public int Sens3;
}