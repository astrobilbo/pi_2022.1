using UnityEngine;
using Cinemachine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] int Velocity = 500;

    CinemachineFreeLook freeLookComponent;

    private void Awake()
    {
        freeLookComponent = GetComponent<CinemachineFreeLook>();
    }

    private void Update()
    {

        freeLookComponent.m_XAxis.m_MaxSpeed = Velocity;
        if (Input.mouseScrollDelta.y != 0)
        {
            freeLookComponent.m_YAxis.m_MaxSpeed = 10;
        }

    }
}