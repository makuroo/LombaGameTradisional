using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BatuHilang());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator BatuHilang()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
