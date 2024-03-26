using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody enemyRb;
    Scoreboard scoreBoard;

    [SerializeField] int enemyHealth = 100;
    [SerializeField] int enemyHPDecrease;
    [SerializeField] int enemyScore = 10;
    [SerializeField] ParticleSystem hitVFX;
    [SerializeField] ParticleSystem enemyExplosion;

    private void Start()
    {
        scoreBoard = FindObjectOfType<Scoreboard>();
        enemyRb = gameObject.AddComponent<Rigidbody>();
        enemyRb.useGravity = false;
    }
    private void OnParticleCollision(GameObject other)
    {

        if (gameObject.CompareTag("EnemySmall"))
        {
            EnemySmallHitting();
        }
        else if (gameObject.CompareTag("EnemyMedium"))
        {
            EnemyMediumHitting();
        }
        else if (gameObject.CompareTag("EnemyLarge"))
        {
            EnemyLargeHitting();
        }
    }

    private void EnemySmallHitting()
    {
        //hitVFX.Play();
        Debug.Log($"EnemySmall HP is {enemyHealth}");
        if (enemyHealth > 0)
        {
            enemyHealth -= enemyHPDecrease;
        }
        if (enemyHealth < 1)
        {
            StartCoroutine(EnemyDestroy());
            //scoreBoard.ScoreCalculation(enemyScore); --- Moved this line to the EnemyDestroy()
        }
    }

    void EnemyMediumHitting()
    {
        hitVFX.Play();
        Debug.Log($"EnemyMedium HP is {enemyHealth}");
        if (enemyHealth > 0)
        {
            enemyHealth -= enemyHPDecrease;
        }
        if (enemyHealth < 1)
        {
            StartCoroutine(EnemyDestroy());
            //scoreBoard.ScoreCalculation(enemyScore); --- Moved this line to the EnemyDestroy()
        }
    }

    void EnemyLargeHitting()
    {
        hitVFX.Play();
        Debug.Log($"EnemyLarge HP is {enemyHealth}");
        if (enemyHealth > 0)
        {
            enemyHealth -= enemyHPDecrease;
        }
        if (enemyHealth < 1)
        {
            StartCoroutine(EnemyDestroy());
            //scoreBoard.ScoreCalculation(enemyScore); --- Moved this line to the EnemyDestroy()
        }
    }

    IEnumerator EnemyDestroy()
    {
        enemyExplosion.Play();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        scoreBoard.ScoreCalculation(enemyScore);
    }
}
