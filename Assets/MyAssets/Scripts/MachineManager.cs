using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MachineManager : MonoBehaviour
{
    public TextAsset ta_textJSON;
    private GameObject go_findedMachines;
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
        float n_plant_efficiency = 0;
        int n_production_rate = Random.Range(0,240);
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

        n_plant_efficiency = (n_avalible_machines * 100f) / l_machines.Count; 

        t_dashboard_Text.text = "Steel Plant Monitoring Dashboard\r\nCurrent avaliable machines : " + n_avalible_machines + " \r\nWarning alerts : " + n_warnings + "\r\nOffline machines " + n_offline_machines + "\r\nPlant efficiency: "+ n_plant_efficiency + "%" + "\r\nProduction rate: " + n_production_rate + "t/h" + "\r\nLast Update: " + System.DateTime.Now.ToString("HH:mm:ss");
    }

    private void TransferData(Machine machine)
    {
        MachineLogic machineLogic = go_findedMachines.GetComponent<MachineLogic>();
        machineLogic.info.s_name = machine.s_name;
        machineLogic.info.s_status = machine.s_status;
        machineLogic.info.n_temperature = machine.n_temperature;
        machineLogic.info.n_max_temperature = machine.n_max_temperature;
        machineLogic.info.n_min_temperature = machine.n_min_temperature;
    }

    private void LoadInformation(int index)
    {
        go_findedMachines = GameObject.Find(l_mymachineList.machine[index].s_name);

        if (go_findedMachines != null)
        {
            l_machines.Add(go_findedMachines.GetComponent<MachineLogic>());
            TransferData(l_mymachineList.machine[index]);
            go_findedMachines.GetComponent<MachineLogic>().InitializeMachine();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        l_mymachineList = JsonUtility.FromJson<MachineList>(ta_textJSON.text);

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
