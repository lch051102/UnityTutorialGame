using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� �Է¹޴� ���� ����

public class PenguinInput : MonoBehaviour
{
    public string HorizontalName = "Horizontal";
    public string JumpInputName = "Jump";

    public Vector3 HorizontalMoveDiraction { get; private set; }
    public bool Jumpinput;

    private void Update()
    {
        MoveSystem();
    }

    private void MoveSystem()
    {
        //�¿� �������� ����ҿ���
        HorizontalMoveDiraction = new Vector3(
            Input.GetAxis(HorizontalName), 0f, 0f);
        Debug.Log(HorizontalMoveDiraction);

        Jumpinput = Input.GetButtonDown(JumpInputName);

    }
}
