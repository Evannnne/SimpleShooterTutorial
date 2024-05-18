using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private NavMeshAgent m_agent;
    private PlayerBehaviour m_player;

    public float health = 100;

    // Start is called before the first frame update
    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_player = FindObjectOfType<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        m_agent.SetDestination(m_player.transform.position);
    }

    public void Hit(float damage)
    {
        FlashRed();
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }


    #region Pre-Included Code
    private Coroutine m_currentFlashCoroutine;
    private void FlashRed()
    {
        if (m_currentFlashCoroutine != null) StopCoroutine(m_currentFlashCoroutine);
        StartCoroutine(_FlashRed());
    }
    private IEnumerator _FlashRed()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<MeshRenderer>().material.color = Color.white;
    }
    #endregion
}
