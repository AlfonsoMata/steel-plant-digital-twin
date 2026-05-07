using System;
using TMPro;
using UnityEngine;
using static json_reader;

public class MachineLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    private GameObject go_canvas_holder;

    private Renderer r_machine_renderer;
    private TextMeshProUGUI tmpg_machine_text;

    public class InternalInfo
    {
        public string s_name;
        public string s_status;
        public int n_temperature;
        public int n_max_temperature;
        public int n_min_temperature;
    }

    public InternalInfo info;

    public void InitializeMachine()
    {
        tmpg_machine_text = go_canvas_holder.GetComponent<TextMeshProUGUI>();
        tmpg_machine_text.text = "Name: " + info.s_name + "\n Status: " + info.s_status + "\n Temperature: " + info.n_temperature + "°C";
        r_machine_renderer = GetComponent<Renderer>();

        switch (info.s_status)
        {
            case "Running":
                r_machine_renderer.material.color = Color.green;
                break;

            case "Warning":
                r_machine_renderer.material.color = Color.yellow;
                break;

            case "Offline":
                r_machine_renderer.material.color = Color.red;
                break;

            default:
                Debug.Log("maquina no encontrada");
                break;
        }

        InvokeRepeating("UpdateMachine", 0f, 5f);
    }

    private void UpdateMachine()
    {
        info.n_temperature += UnityEngine.Random.Range(-20, +20);

        if (info.n_temperature <= 0)
        {
            info.s_status = "Offline";
            r_machine_renderer.material.color= Color.red;
            info.n_temperature = 0;
        }
        else if (info.n_temperature > info.n_max_temperature || info.n_temperature < info.n_min_temperature)
        {
            info.s_status = "Warning";
            r_machine_renderer.material.color = Color.yellow;
        }
        else
        {
            info.s_status = "Running";
            r_machine_renderer.material.color = Color.green;
        }

        tmpg_machine_text.text = "Name: " + info.s_name + "\n Status: " + info.s_status + "\n Temperature: " + info.n_temperature + "°C";
    }

    void Start()
    {
       info = new InternalInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
