using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyLOS : MonoBehaviour
{
    [SerializeField] private Transform[] lineOfSightPos;
    [SerializeField] private float lineOfSightRadius;
    
    [SerializeField] private LayerMask mask;
    private RaycastHit2D[] hitInfo = new RaycastHit2D[3];
    private int lastDetectPlayerHitInfoIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        InitializeHitInfo();
        if (CheckHitInfoStatus())
        {
            if (HitPlayerHitInfoIndex() && transform.GetComponentInParent<AIDestinationSetter>().target != hitInfo[lastDetectPlayerHitInfoIndex].collider.transform)
            {
                Debug.Log("met player");
                transform.GetComponentInParent<AIDestinationSetter>().target = hitInfo[lastDetectPlayerHitInfoIndex].collider.transform;
                transform.GetComponentInParent<AIPath>().maxSpeed *= 2;
            }

        }
        DrawLineOfSight();
    }

    private void InitializeHitInfo()
    {
        hitInfo[0] = Physics2D.Raycast(lineOfSightPos[0].position, lineOfSightPos[0].up, lineOfSightRadius, mask);
        hitInfo[1] = Physics2D.Raycast(lineOfSightPos[1].position, lineOfSightPos[1].up, lineOfSightRadius, mask);
        hitInfo[2] = Physics2D.Raycast(lineOfSightPos[2].position, lineOfSightPos[2].up, lineOfSightRadius, mask);
    }

    private void DrawLineOfSight()
    {
        for (int i = 0; i < hitInfo.Length; i++)
        {
            if (hitInfo[i].collider != null)
                Debug.DrawLine(lineOfSightPos[i].position, hitInfo[i].point, Color.red);
            else
                Debug.DrawLine(lineOfSightPos[i].position, transform.up * lineOfSightRadius + lineOfSightPos[i].position, Color.green);
        }

    }

    private bool CheckHitInfoStatus()
    {
        if (hitInfo[0].collider == null && hitInfo[1].collider == null && hitInfo[2].collider == null)
            return false;
        else
            return true;
    }

    private bool HitPlayerHitInfoIndex()
    {
        for (int i = 0; i < hitInfo.Length; i++)
        {
            if (hitInfo[i].collider!=null && hitInfo[i].collider.CompareTag("Player"))
            {
                lastDetectPlayerHitInfoIndex = i;
                return true;
            }
        }
        return false;
    }
}
