using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public Image healthBar;
    public float playerHealth;
    public float currentHealth;
    public Player_Controller player;
    public CinemachineVirtualCamera cam;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerHealth;
    }

    private void Update()
    {
        if(gameObject.transform.position.y < - 20)
        {
            KillBox();
        }
    }

    public void TakeDMG(float damage)
    {

        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / playerHealth;
        if(currentHealth<=0)
        {
            cam.enabled = false;
            player.gameover = true;
            player.PlayerDead();
            StartCoroutine(transitionOut());
        }
    }

    void KillBox()
    {
        TakeDMG(currentHealth);
    }

    IEnumerator transitionOut()
    {
        yield return new WaitForSeconds(3.0f);
        anim.SetTrigger("GameOver");

        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
