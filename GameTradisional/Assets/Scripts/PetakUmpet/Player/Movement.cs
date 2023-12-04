using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    private float currSpeed;
    public float horizontalInput { get; private set; }
    public float verticalInput { get; private set; } 
    public bool isRunning { get; private set; }
    public bool isMoving { get; private set; }
    private Camera mainCam;
    private Vector3 mousePos;
    [SerializeField]private float rotateSpeed;
    [SerializeField] private AudioManager audioManager;
    public bool canGetOut = false;

    // Start is called before the first frame update
    void Start()
    {
        
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        isMoving = horizontalInput != 0 || verticalInput != 0;

        currSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed;
        isRunning = Input.GetKey(KeyCode.LeftShift);

        if (isMoving)
            audioManager.PlayOneShot("Walk");

        if (isRunning)
            audioManager.SetPitch("Walk", 2);
        else
            audioManager.SetPitch("Walk", 1);


        transform.Translate(new Vector2(horizontalInput, verticalInput).normalized * currSpeed * Time.deltaTime);
        LightRotation();
    }

    private void LightRotation()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(transform.position, mousePos) > 1)
        {
            Vector2 rotation = (mousePos - transform.position);
            transform.up = rotation;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("OutGate") && canGetOut)
        {
            SceneManager.LoadScene(2);
        }
    }
}
