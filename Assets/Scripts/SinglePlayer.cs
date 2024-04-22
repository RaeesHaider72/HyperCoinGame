using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayer : MonoBehaviour
{
    public GameObject character1;
    private Vector3 cha1Position;
    private Quaternion cha1Rotation;


    private void Awake()
    {
        cha1Position = character1.transform.position;
        cha1Rotation = character1.transform.rotation;
    }


    private void OnEnable()
    {

        character1.transform.position = cha1Position;
        character1.transform.rotation = cha1Rotation;
    }
}
