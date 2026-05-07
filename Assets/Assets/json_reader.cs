using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class json_reader : MonoBehaviour
{
    public TextAsset textJSON;

    [SerializeField]
    private GameObject[] machines;

    [System.Serializable]
    public class Machine
    {
        public string name;
        public string status;
        public int temperature;
    }

    private Renderer TempRenderer;

    [System.Serializable]
    public class MachineList
    {
        public Machine[] machine;
    }

    public MachineList mymachineList = new MachineList();

    private void ChangeMachineColor(int index)
    {
        if (mymachineList.machine[index].name == machines[index].name)
        {
            TempRenderer = machines[index].GetComponent<Renderer>();
            switch (mymachineList.machine[index].status)
            {
                case "running":
                    TempRenderer.material.color = Color.green;
                    break;

                case "warning":
                    TempRenderer.material.color = Color.yellow;
                    break;

                case "offline":
                    TempRenderer.material.color = Color.red;
                    break;

                default:
                    Debug.Log("maquina no encontrada");
                    break;
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mymachineList = JsonUtility.FromJson<MachineList>(textJSON.text);

        for (int i = 0; i < mymachineList.machine.Length; i++)
        {
            ChangeMachineColor(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
