using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pipe : MonoBehaviour
{
    public Text Score;
    public GameObject gameObjects, White, Quit;
    
    Rigidbody2D rig;
    
    int i, BestScore;
    bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(Vector3.up * 270);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        if (gameOver) return;

        if(((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0)))
        {
            rig.velocity = Vector3.zero;
            rig.AddForce(Vector3.up * 270);
        }

        if(transform.position.x > 2.5f || transform.position.y < -4f)
        {
            GameOver();
            Quit.transform.Find("ScoreScreen").GetComponent<Text>().text = Score.text;
            Quit.transform.Find("BestScreen").GetComponent<Text>().text = PlayerPrefs.GetInt("BestScore").ToString();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Bird(Clone)") 
        {
            Score.text = (++i).ToString();
        }
    }

    void GameOver() 
    {
        gameOver = true;
        White.SetActive(true);
        Score.gameObject.SetActive(false);
        Quit.SetActive(true);
        if (PlayerPrefs.GetInt("BestScore", 0) < int.Parse(Score.text)) PlayerPrefs.SetInt("BestScore",int.Parse(Score.text));
    }

    public void Restart()
    {
        gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
