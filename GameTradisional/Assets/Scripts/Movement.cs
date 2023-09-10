using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private float rotz;
    private Camera mainCam;
    private Vector3 mousePos;
    [SerializeField]private float rotateSpeed;

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
        transform.Translate(new Vector2(horizontalInput, verticalInput).normalized * speed * Time.deltaTime);
        LightRotation();
    }

    private void LightRotation()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rotation = (mousePos - transform.position);
        transform.up = rotation;
    }

}
