using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] GameObject body;

    AudioSource explosionSFX;

    private void Start()
    {
        explosionSFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"collided with {other.gameObject.name}");
        StartCoroutine(SceneReload());
    }

    IEnumerator SceneReload()
    {
        explosionSFX.Play();
        explosionParticles.Play();
        body.SetActive(false);
        GetComponent<Playercontroller>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        int opennedSceneIndex = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(opennedSceneIndex);
    }
}
