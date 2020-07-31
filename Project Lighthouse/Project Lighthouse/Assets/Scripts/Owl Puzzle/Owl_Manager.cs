using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl_Manager : MonoBehaviour
{
    public Owl_dialPositions theDialPositions;

    [SerializeField] Dial_Script[] dials;

    // Start is called before the first frame update
    void Start()
    {
        dials = FindObjectsOfType<Dial_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        theDialPositions.Dial1 = dials[0].lookingAtAngle;
        theDialPositions.Dial2 = dials[1].lookingAtAngle;
        theDialPositions.Dial3 = dials[2].lookingAtAngle;
    }
}

public struct Owl_dialPositions
{
    public Owl_dialPositions(float dial1, float dial2, float dial3)
    {
        Dial1 = dial1;
        Dial2 = dial2;
        Dial3 = dial3;
    }

    public float Dial1;
    public float Dial2;
    public float Dial3;

    public override string ToString()
    {
        return (Dial1 + " " + Dial2 + " " + Dial3);
    }

    public float Sum()
    {
        return (Dial1 + Dial2 + Dial3);
    }

    public float SumSens(int Sens1, int Sens2, int Sens3)
    {
        return (Dial1*Sens1 + Dial2*Sens2 + Dial3*Sens3);
    }
}