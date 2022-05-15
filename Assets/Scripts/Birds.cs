using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{
    public bool gameOver;

    public GameObject Bird;

    float NextTime = 0;
    int j = 0;
    
    GameObject[] gameObjects = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (gameOver) return;

        if (Time.time > NextTime) 
        {
            NextTime = Time.time + 1.7f;
            gameObjects[j] = (GameObject)Instantiate(Bird, new Vector3(-4, Random.Range(-1f, 3.2f),0), Quaternion.identity);
            if (++j == 3) j = 0;
        }
        
        if (gameObjects[0])
        {
            gameObjects[0].transform.Translate(3f * Time.deltaTime,0,0);
            if (gameObjects[0].transform.position.x > 4) Destroy(gameObjects[0]);
        }
        if (gameObjects[1])
        {
            gameObjects[1].transform.Translate(3f * Time.deltaTime,0,0);
            if (gameObjects[1].transform.position.x > 4) Destroy(gameObjects[1]);
        }
        if (gameObjects[2])
        {
            gameObjects[2].transform.Translate(3f * Time.deltaTime,0,0);
            if (gameObjects[2].transform.position.x > 4) Destroy(gameObjects[2]);
        }
        
    }
    
}
