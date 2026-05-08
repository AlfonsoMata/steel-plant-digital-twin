using UnityEngine;

public class MachineTag : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    private Camera m_Camera;
    private Transform m_Transform; 

    void Start()
    {
        m_Transform = m_Camera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(m_Transform);
    }
}
