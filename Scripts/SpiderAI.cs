using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAI : MonoBehaviour
{
    public Transform[] patrolPoints;

    public float speed = 2.0f;
    Transform currentPatrol;
    int currentPatrolIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentPatrolIndex = 0;
        currentPatrol = patrolPoints[currentPatrolIndex];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if(Vector3.Distance(transform.position, currentPatrol.position) < 0.1f)
        {
            if(currentPatrolIndex +1 < patrolPoints.Length)
            {
                currentPatrolIndex++;
            }
            else
            {
                currentPatrolIndex = 0;
            }

            currentPatrol = patrolPoints[currentPatrolIndex];
        }

        Vector3 patrolPointDir = currentPatrol.position - transform.position;
        float angle = Mathf.Atan2(patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg -90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);
    }


}
