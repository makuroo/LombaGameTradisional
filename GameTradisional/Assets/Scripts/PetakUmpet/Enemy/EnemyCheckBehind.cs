using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyCheckBehind : MonoBehaviour
{
    [SerializeField] private float timeBeforeCheck;
    [SerializeField] private float currTime;
    [SerializeField] private float returnTime;
    [SerializeField] private AIPath aiPath;
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
            aiPath.updateRotation = false;
            hasRotate = true;
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 180);
            StartCoroutine(ReturnRotation());
        }
    }

    private IEnumerator ReturnRotation()
    {
        yield return new WaitForSeconds(returnTime);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 180);
        aiPath.updateRotation = true;
        currTime = timeBeforeCheck;
        hasRotate = false;
    } 
}
