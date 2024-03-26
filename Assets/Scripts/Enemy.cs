using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Scoreboard scoreBoard;

    [SerializeField] int scorePerHit = 5;
    [SerializeField] ParticleSystem enemyExplosion;

    private void Start()
    {
        scoreBoard = FindObjectOfType<Scoreboard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log("Hitted");
        scoreBoard.ScoreCalculation(scorePerHit);
        StartCoroutine(EnemyDestroy());
    }

    IEnumerator EnemyDestroy()
    {
        enemyExplosion.Play();
        GetComponent<SphereCollider>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
