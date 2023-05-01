using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RespawnTimer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] float respawnTime;
    float currentTime;
    [SerializeField] PlayerStats playerStats;
    bool isStartTimer;
    [SerializeField] Transform respawnPoint;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        playerStats.OnPlayerDies += PlayerStats_OnPlayerDies;
       
    }

    private void PlayerStats_OnPlayerDies(object sender, System.EventArgs e)
    {
        currentTime = respawnTime;
        isStartTimer = true;
        StartCoroutine(DeathTimeCorotine(respawnTime));
    }

    IEnumerator DeathTimeCorotine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        playerStats.transform.position = respawnPoint.position;
        player.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
        if (isStartTimer)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                isStartTimer = false;
                currentTime = 0f;
            }
            textMesh.text = currentTime.ToString();
        }
    }
}
