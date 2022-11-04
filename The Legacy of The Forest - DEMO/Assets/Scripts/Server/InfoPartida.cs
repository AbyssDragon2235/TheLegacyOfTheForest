using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPartida : MonoBehaviour
{
    [SerializeField] public string final = "No establecido";
    [SerializeField] public float decisiones;
    [SerializeField] public int dinero;
    public GameObject infoPartida;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            infoPartida.SetActive(!infoPartida.activeSelf);
        }
    }
}
