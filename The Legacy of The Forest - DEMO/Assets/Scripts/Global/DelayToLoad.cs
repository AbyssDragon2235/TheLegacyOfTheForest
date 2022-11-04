using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayToLoad : MonoBehaviour
{
    public SceneSwitcher sceneSwitcher;

    [SerializeField]
    private float delayBeforeLoading = 10f;
    [SerializeField]
    private float timeElapsed;
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforeLoading)
        {
            sceneSwitcher.playGame();
        }
    }
}
