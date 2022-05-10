using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    [SerializeField]
    private string _tag;
    public int tien;
    public int slowDown;
    // Start is called before the first frame update
    void Awake() {
        this.tag = _tag;
    }

    // Update is called once per frame
}
