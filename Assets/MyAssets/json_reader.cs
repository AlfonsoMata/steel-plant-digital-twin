using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class json_reader : MonoBehaviour
{
    public TextAsset textJSON;
    private GameObject findedMachines;
    private List<MachineLogic> l_machines = new List<MachineLogic>();

    [SerializeField]
    private TextMeshProUGUI t_dashboard_Text;

    [System.Serializable]
    public class Machine
    {
        public string s_name;
        public string s_status;
        public int n_temperature;
        public int n_max_temperature;
        public int n_min_temperature;
    }

    [System.Serializable]
    public class MachineList
    {
        public Machine[] machine;
    }

    public MachineList l_mymachineList = new MachineList();


    private void CheckMachines()
    {

        int n_avalible_machines = 0;
        int n_warnings = 0;
        int n_offline_machines = 0;

        for (int i = 0; i < l_machines.Count; i++)
        {
            switch(l_machines[i].info.s_status)
            {
                case "Running":
                    n_avalible_machines++;
                    break;

                case "Warning":
                    n_warnings++;
                    break;

                case "Offline":
                    n_offline_machines++;
                    break;

                default:
                    Debug.Log("maquina no encontrada");
                    break;
            }
        }

        t_dashboard_Text.text = "Steel Plant Monitoring Dashboard\r\nCurrent avaliable machines : " + n_avalible_machines + " \r\nWarning alerts : " + n_warnings + "\r\nOffline machines " + n_offline_machines;
    }

    private void TransferData(Machine machine)
    {
        MachineLogic machineLogic = findedMachines.GetComponent<MachineLogic>();
        machineLogic.info.s_name = machine.s_name;
        machineLogic.info.s_status = machine.s_status;
        machineLogic.info.n_temperature = machine.n_temperature;
        machineLogic.info.n_max_temperature = machine.n_max_temperature;
        machineLogic.info.n_min_temperature = machine.n_min_temperature;
    }

    private void LoadInformation(int index)
    {
        findedMachines = GameObject.Find(l_mymachineList.machine[index].s_name);

        if (findedMachines != null)
        {
            l_machines.Add(findedMachines.GetComponent<MachineLogic>());
            TransferData(l_mymachineList.machine[index]);
            findedMachines.GetComponent<MachineLogic>().InitializeMachine();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        l_mymachineList = JsonUtility.FromJson<MachineList>(textJSON.text);

        for (int i = 0; i < l_mymachineList.machine.Length; i++)
        {
            LoadInformation(i);
        }

        InvokeRepeating("CheckMachines", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
