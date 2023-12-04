using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCompass : MonoBehaviour
{
    [SerializeField] GameObject ghost;
    [SerializeField] GameObject player;
    [SerializeField] float currentTime;
    [SerializeField] float timeToRotate;
    private Vector2 dirVector;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = timeToRotate;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RotateArrow()
    {

        Vector3 directionToB = (ghost.transform.position - player.transform.position).normalized;
        Debug.Log(directionToB);
        // Calculate the rotation angle in radians using Mathf.Atan2
        float angle = Mathf.Atan2(directionToB.y, directionToB.x) * Mathf.Rad2Deg;
        if (angle < 0)
            angle = -angle;
        // Apply the rotation to the compass arrow image
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
