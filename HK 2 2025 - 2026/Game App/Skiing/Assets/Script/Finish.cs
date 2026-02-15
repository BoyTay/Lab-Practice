using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    [SerializeField] float timeDelay = 2f;
    [SerializeField] ParticleSystem particleFinish;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Ban da ve dich!");
            particleFinish.Play();
            GetComponent<AudioSource>().Play();
            //Invoke("LoadScene", timeDelay);
        }
    }
    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
