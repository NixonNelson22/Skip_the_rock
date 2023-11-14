using UnityEngine;
using Cinemachine;

public class followRock : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CinemachineFreeLook cinemachineFreeLook ;

    void Start()
    {
        cinemachineFreeLook.m_XAxis.m_InputAxisName = "";
        cinemachineFreeLook.m_YAxis.m_InputAxisName = "";
        Vector3 position = transform.position;
        Vector3 rotation = transform.rotation.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
