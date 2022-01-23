using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    //<>
    public Transform enemyPrefab; //busca prefab inimigo

    public Transform spawnPoint; //busca start

    public float timeBetweenWaves = 5f; //de 5 em 5 segundos nascem novos inimigos
    private float countdown = 2f; //quando o jogo começa espera 2 segundos até nascerem os primeiros inimigos

    public Text waveCountdownText; //se quiseres usar texto para aparecer o tempo ate nascerem mais no ecra

    private int waveIndex = 0; //começa na ronda 0

    private void Update()
    {
        if (countdown <= 0f) //se nao faltar tempo começa
        {
            StartCoroutine(SpawnWave()); //vai pa corotina
            countdown = timeBetweenWaves; //countdown passa a ser 5
        }

        countdown -= Time.deltaTime; //tira por cada segundo 1 ao countdown

        waveCountdownText.text = Mathf.Round(countdown).ToString(); //se usares texto
    }

    IEnumerator SpawnWave() //corotina
    {
        waveIndex++; //de ronda 0 passa pa 1, de 1 pa 2 etc
        for (int i = 0; i < waveIndex; i++) //numero de inimigos spawnados corresponde ao numero da ronda (ronda 3 spawna 3 inimigos)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
