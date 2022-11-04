using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Status : MonoBehaviour
{
    public PlayerController player;

    public GameObject status;
    public TextMeshProUGUI goldText;

    public void Update()
    {
        goldText.text = player.gold.ToString();
    }
}
