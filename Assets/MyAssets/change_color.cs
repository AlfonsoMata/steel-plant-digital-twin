using UnityEngine;
using UnityEngine.UI;
public class change_color : MonoBehaviour
{
    [SerializeField]

    private GameObject cube;

    private Renderer cubeRenderer;

    private Color newColorCube;

    private float randomChanelOne, randomChanelTwo, randomChanelThree;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cubeRenderer = cube.GetComponent<Renderer>();
        gameObject.GetComponent<Button>().onClick.AddListener(changeRandomColor);
    }

    private void changeRandomColor()
    {
        randomChanelOne = Random.Range(0f, 1f);
        randomChanelTwo = Random.Range(0f, 1f);
        randomChanelThree = Random.Range(0f, 1f);

        newColorCube = new Color(randomChanelOne,randomChanelTwo,randomChanelThree, 1f);
        Debug.Log("me estoy ejecutando");
        Debug.Log(newColorCube);
        Debug.Log(cubeRenderer.name);
        cubeRenderer.material.color = newColorCube;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
