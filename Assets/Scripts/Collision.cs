using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] GameObject body;
    [SerializeField] GameObject resetMenu;

    AudioSource explosionSFX;

    private void Start()
    {
        explosionSFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.gameObject.CompareTag("FinalPoint"))
        {
            Debug.Log($"collided with {other.gameObject.name}");
            StartCoroutine(SceneReload());
        }
        else if (other.gameObject.CompareTag("FinalPoint"))
        {
            StartCoroutine(NextSceneLoad());
        }
    }

    IEnumerator SceneReload()
    {
        explosionSFX.Play();
        explosionParticles.Play();
        body.SetActive(false);
        GetComponent<Playercontroller>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.7f);
        resetMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    IEnumerator NextSceneLoad()
    {
        GetComponent<Playercontroller>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void resetScene()
    {
        Time.timeScale = 1f;
        resetMenu.SetActive(false);
        int opennedSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(opennedSceneIndex);
    }
}
