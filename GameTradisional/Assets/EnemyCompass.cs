using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCompass : MonoBehaviour
{
    [SerializeField] GameObject ghost;
    [SerializeField] GameObject player;
    private Vector2 dirVector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        dirVector = ghost.transform.position - player.transform.position;
        float angleRadians = Mathf.Atan2(dirVector.y, dirVector.x);
        
        Quaternion rotation = Quaternion.Euler(0, 0, angleRadians * Mathf.Rad2Deg);
        Debug.Log(angleRadians * Mathf.Rad2Deg);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 2*Time.deltaTime);
    }
}
