using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Crucible"))
        {
            gameObject.SetActive(false);
            GameManager.Continue(transform.position);
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            gameObject.SetActive(false);
            GameManager.GameOver();
        }
    }
}
