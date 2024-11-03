using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public FixedJoystick joy;
    private float speed = 5 ; 
    Animator ani;

    float degStop;
    // Start is called before the first frame update
    void Start()
    {
        ani = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float dx = joy.Horizontal;
        float dy = joy.Vertical;

        float rad = Mathf.Atan2(dx - 0, dy - 0);

        float deg = rad * Mathf.Rad2Deg;

        this.transform.rotation = Quaternion.Euler(0, deg, 0);

        if(deg!=0)
        {
            ani.SetBool("Walk", true);
            this.transform.position += this.transform.forward * speed * Time.deltaTime;

            degStop = deg;
        }
        else
        {
            ani.SetBool("Walk", false);

            this.transform.rotation = Quaternion.Euler(0, degStop, 0);
        }
    }
}
