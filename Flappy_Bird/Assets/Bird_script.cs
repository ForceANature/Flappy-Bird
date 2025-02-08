using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

public class Bird_script : MonoBehaviour
{
    public LogicScript logic;
    public Rigidbody2D birdRigidbody;
    public float flapStrength;
    public bool birdIsAlive = true;
    public float birdDeadZoneUp = 18;
    public float birdDeadZoneDown = -17;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            birdRigidbody.velocity = Vector2.up * flapStrength;
            animator.SetTrigger("Flop");
        }

        if (transform.position.y > birdDeadZoneUp || transform.position.y < birdDeadZoneDown)
        {
            logic.GameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        birdIsAlive = false;
    }

}
