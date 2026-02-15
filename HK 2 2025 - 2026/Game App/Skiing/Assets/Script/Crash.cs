using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Crash : MonoBehaviour
{
    private const bool V = true;
    [SerializeField] float timeDelay = 2f;
    [SerializeField] ParticleSystem particleCrash;
    [SerializeField] AudioClip audioCrash;

    bool hasCrashed = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            Debug.Log("Game Over!");
            FindAnyObjectByType<Controller>().StopMove();
            particleCrash.Play();
            GetComponent<AudioSource>().PlayOneShot(audioCrash);
            Invoke("LoadScene", timeDelay);
        }
    }
    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
