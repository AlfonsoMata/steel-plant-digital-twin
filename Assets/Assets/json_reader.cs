using System;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class json_reader : MonoBehaviour
{
    public TextAsset textJSON;

    private GameObject findedMachines;

    [System.Serializable]
    public class Machine
    {
        public string name;
        public string status;
        public int temperature;
    }

    private Renderer TempRenderer;

    private TextMeshProUGUI TempTextTag;

    [System.Serializable]
    public class MachineList
    {
        public Machine[] machine;
    }

    public MachineList mymachineList = new MachineList();

    private void ChangeMachineColor(int index)
    {
        findedMachines = GameObject.Find(mymachineList.machine[index].name);
        if (findedMachines != null)
        {

            TempRenderer = findedMachines.GetComponent<Renderer>();
            TempTextTag = findedMachines.GetComponentInChildren<TextMeshProUGUI>();
            TempTextTag.text = "Name: " + mymachineList.machine[index].name + "\n Status: " + mymachineList.machine[index].status + "\n Temperatura: " + mymachineList.machine[index].temperature;
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
