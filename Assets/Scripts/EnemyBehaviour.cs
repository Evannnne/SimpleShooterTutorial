using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    // @ TODO: Implement Enemy

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
