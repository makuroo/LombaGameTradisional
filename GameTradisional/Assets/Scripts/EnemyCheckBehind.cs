using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheckBehind : MonoBehaviour
{
    [SerializeField] private float timeBeforeCheck;
    [SerializeField] private float currTime;
    [SerializeField] private float returnTime;
    private bool hasRotate = false;

    // Start is called before the first frame update
    void Start()
    {
        currTime = timeBeforeCheck;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currTime >= 0)
        {
            currTime -= Time.deltaTime;
        }else if (currTime <= 0 && !hasRotate)
        {
            hasRotate = true;
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 180);
            StartCoroutine(ReturnRotation());
        }
    }

    private IEnumerator ReturnRotation()
    {
        yield return new WaitForSeconds(returnTime);
        currTime = timeBeforeCheck;
        hasRotate = false;
    } 
}
