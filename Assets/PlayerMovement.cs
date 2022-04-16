using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float currentTime;
    public float startTime;
    public GameObject winScreen;
    public GameObject failScreen;
    public Text countDownText;
    private TrailRenderer TR;

    private float normalSpeed = 2;
    private float specialSpeed = 1;
    private bool stopCountDown;
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;

    // Start is called before the first frame update
    void Start()
    {
        TR = GetComponent<TrailRenderer>();
        currentTime = startTime;
        playerSpeed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();

        if (stopCountDown != true)
        {
            currentTime -= 1 * Time.deltaTime;
            countDownText.text = currentTime.ToString("00.00");
        }
        if (currentTime <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            failScreen.SetActive(true);
            stopCountDown = true;
            moveRight = true;
            moveLeft = true;
            moveUp = true;
            moveDown = true;
        }

    }

    public void PlayerControl()
    {
        if (Input.GetKeyDown(KeyCode.W) && moveDown != true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, playerSpeed, 0);
            moveUp = true;
            moveDown = false;
            moveLeft = false;
            moveRight = false;
        }
        if (Input.GetKeyDown(KeyCode.S) && moveUp != true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, -playerSpeed, 0);
            moveDown = true;
            moveUp = false;
            moveLeft = false;
            moveRight = false;
        }
        if (Input.GetKeyDown(KeyCode.A) && moveRight != true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(-playerSpeed, 0, 0);
            moveLeft = true;
            moveRight = false;
            moveUp = false;
            moveDown = false;
        }
        if (Input.GetKeyDown(KeyCode.D) && moveLeft != true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(playerSpeed, 0, 0);
            moveRight = true;
            moveLeft = false;
            moveUp = false;
            moveDown = false;

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerSpeed =  specialSpeed;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerSpeed = normalSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "obstacles")
        {
            gameObject.transform.position = new Vector3(-9, -3, 0);
            TR.Clear();
        }
        if (collision.tag == "Finish")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            winScreen.SetActive(true);
            stopCountDown = true;
            moveRight = true;
            moveLeft = true;
            moveUp = true;
            moveDown = true;
            print("over");
        }
    }
}
