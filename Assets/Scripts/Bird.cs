using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject Column;

    Rigidbody2D rig;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(Vector3.up * 270);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        GetComponent<Animator>().SetFloat("Velocity",rig.velocity.y);
        if(transform.position.y > 4.75f) transform.position = new Vector3(-1.5f,4.75f,0f);
        if(transform.position.y < -2.5f)
        {
            rig.simulated = false;
            GameOver();
        }
        
        if(rig.velocity.y > 0) transform.rotation = Quaternion.Euler(0,0,Mathf.Lerp(transform.rotation.z, 30f, rig.velocity.y /8f));
        else transform.rotation = Quaternion.Euler(0,0,Mathf.Lerp(transform.rotation.z, -70f, -rig.velocity.y/8f));

        if((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {
            rig.velocity = Vector3.zero;
            rig.AddForce(Vector3.up * 270);
        }

    }

    void GameOver()
    {
        Debug.Log("death");
    }
}
