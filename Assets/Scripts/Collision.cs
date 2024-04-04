using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] GameObject body;
    [SerializeField] GameObject resetMenu;
    [SerializeField] GameObject endGame;

    AudioSource explosionSFX;

    private void Start()
    {
        explosionSFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!other.gameObject.CompareTag("FinalPoint") && !other.gameObject.CompareTag("FinalPoint Lvl2"))
        {
            Debug.Log($"collided with {other.gameObject.name}");
            StartCoroutine(SceneReload());
        }
        else if (other.gameObject.CompareTag("FinalPoint"))
        {
            StartCoroutine(NextSceneLoad());
        }
        else if (other.gameObject.CompareTag("FinalPoint Lvl2"))
        {
            StartCoroutine(EndGameMethod());
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

    IEnumerator EndGameMethod()
    {
        GetComponent<Playercontroller>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        endGame.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resetScene()
    {
        Time.timeScale = 1f;
        resetMenu.SetActive(false);
        int opennedSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(opennedSceneIndex);
    }
}
