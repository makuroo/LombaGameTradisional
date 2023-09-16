using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    public float horizontalInput { get; private set; }
    public float verticalInput { get; private set; }
    [SerializeField] private float rotz;
    private Camera mainCam;
    private Vector3 mousePos;
    [SerializeField]private float rotateSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(horizontalInput, verticalInput).normalized * speed * Time.deltaTime);
        LightRotation();
    }

    private void FixedUpdate()
    {
        rb.velocity  = new Vector2(horizontalInput, verticalInput).normalized * speed * Time.fixedDeltaTime * Vector2.right;
    }

    private void LightRotation()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rotation = (mousePos - transform.position);
        transform.up = rotation;
    }

}
