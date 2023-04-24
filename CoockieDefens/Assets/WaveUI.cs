using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] WaveSpawner thisWaveSpawner;

    private void Start()
    {
        thisWaveSpawner = WaveSpawner.instance;
        thisWaveSpawner.OnWaveFinish += ThisWaveSpawner_OnWaveFinish;
    }

    private void ThisWaveSpawner_OnWaveFinish(object sender, System.EventArgs e)
    {
        RefreshGui();
    }

    private void RefreshGui()
    {
        textMesh.text = thisWaveSpawner.currentWave.ToString();
        
    }
}
