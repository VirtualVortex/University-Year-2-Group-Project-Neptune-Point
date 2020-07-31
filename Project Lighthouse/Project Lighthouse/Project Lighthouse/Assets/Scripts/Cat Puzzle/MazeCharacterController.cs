using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCharacterController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Manager mm;
    [SerializeField]
    private float force;
    [SerializeField]
    private string scene;
    [SerializeField]
    private FailCounter fc;


    Rigidbody rb;
    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal") * speed;
        y = Input.GetAxis("Vertical") * speed;
        rb.AddForce(x * force, y * force, 0, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag.Contains("Border"))
        {
            mm.StartPuzzle();
            Debug.Log("Game over");
            fc.IncreaseTries();
        }
            

        if(collision.transform.name.Contains("End"))
        {
            mm.EndPuzzle(scene);
            Debug.Log("You Win");
        }
            
    }
}
