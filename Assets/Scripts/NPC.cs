using UnityEngine;
using UnityEngine.AI;

using System;
using UnityEngine.UIElements;

public class NPC : MonoBehaviour
{
    NavMeshAgent nav;
    [SerializeField] Transform[] points;
    int i = 0;
    public float count = 0;
    private void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        nav.SetDestination(points[i].position);
        if (Vector3.Distance(transform.position, points[i].position)< count)
        {
            i++;
        }
        if (i >= points.Length)
        {
            i = 0;
        }
    }
}
