using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScripf : MonoBehaviour
{
 private LineRenderer line;
  [SerializeField] private Transform start;
  [SerializeField] private  Transform end;
    Vector3 vStart;
    Vector3 vEnd;
    void Start()
    {
        vStart = start.position;
 
        line = GetComponent<LineRenderer>();

        line.SetPosition(0,vStart);
        line.SetPosition(1, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(1, transform.position);
    }
}
