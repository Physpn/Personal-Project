using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 20.0f;
    public float damage = 15;
    public TextMeshProUGUI titleText;
    private float xRange = 30.0f;
    private float zRange1 = 50.0f;
    private float zRange2 = 53.0f;
    private Camera mainCamera;
    public Button restartButton;
    public Button startButton;
    public int force;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        Time.timeScale = 0;
    }

        void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -zRange2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange2);
        }
        if (transform.position.z > zRange1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * force);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * force);
        }


        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
    }
    public void StartGame()
    {
        startButton.gameObject.SetActive(false);
        Time.timeScale = 1;
        titleText.gameObject.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
