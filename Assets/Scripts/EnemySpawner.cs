using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRadiusMax = 5f;
    public float spawnRadiusMin = 20;
    public float spawnRate = 5;
    public GameObject enemyPrefab;

    private PlayerBehaviour m_player;
    private float m_elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_player = FindObjectOfType<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        m_elapsedTime += Time.deltaTime;
        if(m_elapsedTime >= spawnRate)
        {
            Vector3 randomPos = m_player.transform.position + Random.onUnitSphere * Random.Range(spawnRadiusMin, spawnRadiusMax);
            randomPos.y = 1;

            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = randomPos;

            m_elapsedTime = 0;
        }
    }
}
