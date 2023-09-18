using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] private AIPath aiPath;
    [SerializeField] private AIDestinationSetter destinationSetter;
    [SerializeField] private List<Transform> nodes;
    [SerializeField] private int nodeIndex = 0;
    [SerializeField] private bool changeNode = false;
    private event EventHandler OnCountDownFinish;
    [SerializeField] private EnemyGlow enemyCountdownStatus;
    [SerializeField] private Movement playerMovement;
    [SerializeField] private float timeBeforeChasingPlayer = 12f;
    [SerializeField] private float currentTime;
    [SerializeField] private GameObject distortion;
    // Start is called before the first frame update

    private void Awake()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();

        currentTime = timeBeforeChasingPlayer;
    }

    private void Start()
    {
        OnCountDownFinish += StartPathfinding;
    }
    private void Update()
    {
        if (destinationSetter.target == playerMovement.transform)
            distortion.SetActive(true);

        //prevent player from camping
        if (playerMovement.horizontalInput == 0 && playerMovement.verticalInput == 0 && playerMovement.enabled && enemyCountdownStatus.isFirstFinish)
        {
            if (currentTime >= 0)
            {
                currentTime -= Time.deltaTime;
            }
            else if (currentTime <= 0)
            {
                destinationSetter.target = playerMovement.transform;
                Debug.Log("TargetPlayer");
                currentTime = timeBeforeChasingPlayer;
            }

            if (currentTime < timeBeforeChasingPlayer && (playerMovement.horizontalInput != 0 || playerMovement.verticalInput != 0))
            {
                currentTime = timeBeforeChasingPlayer;
            }
        }

        //change ai target to next checkpoint
        if (aiPath.reachedEndOfPath&&!changeNode)
        {
            nodeIndex++;
            changeNode = true;
            if (nodeIndex > nodes.Count - 1)
            {
                nodeIndex = 0;
            }
            destinationSetter.target = nodes[nodeIndex];

        }
        if (!aiPath.reachedEndOfPath && changeNode)
        {
            changeNode = false;
        }

        //enemy finish countdown
        if (enemyCountdownStatus.isFirstFinish)
        {
            OnCountDownFinish?.Invoke(this, EventArgs.Empty);
        }
    }

    private void StartPathfinding(object sender, EventArgs e)
    {
        destinationSetter.target = nodes[nodeIndex];
        OnCountDownFinish -= StartPathfinding;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            aiPath.isStopped = true;
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            collision.gameObject.GetComponent<Movement>().enabled = false;
        }
    }
}
