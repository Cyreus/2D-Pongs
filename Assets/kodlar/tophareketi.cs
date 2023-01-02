using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;
public class tophareketi : MonoBehaviour
{
    public float xHizi, yHizi;
    public Rigidbody2D top;
    public TextMeshProUGUI player1yazi, player2yazi,kazananYazisi,bitisYazisi;
    int player1skor,player2skor;
    public int maxSkor;
    public AudioSource skorSesi, kazanmaSesi;
    void Update()
    {
        player1yazi.text = player1skor.ToString();
        player2yazi.text = player2skor.ToString();
        if (Time.timeScale == 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }

    }



    void OnCollisionEnter2D(Collision2D temas)
    {
        if(temas.gameObject.tag == "player1")
        {
            top.velocity = new Vector2(xHizi, Random.Range(-4.3f, 4.3f));

        }
        else if(temas.gameObject.tag == "player2")
        {
            top.velocity = new Vector2(-xHizi, Random.Range(-3.3f, 3.3f));
        }

        if(temas.gameObject.tag == "UstDuvar")
        {
            top.velocity = new Vector2(top.velocity.x, -Random.Range(4.3f, 6f));
           
        }
        else if(temas.gameObject.tag == "AltDuvar")
        {
            top.velocity = new Vector2(top.velocity.x, Random.Range(4.3f, 6f));
        }
        if(temas.gameObject.tag == "SolDuvar")
        {
            player2skor++;
            skorSesi.Play();
            transform.position = new Vector2(-7.419f, 0f);
        }
        else if(temas.gameObject.tag == "SagDuvar")
        {
            player1skor++;
            skorSesi.Play();
            transform.position = new Vector2(7.419f, 0f);

        }
        if (player1skor == maxSkor)
        {
            kazananYazisi.text = "ali kazandý!";
            bitisYazisi.text = "Tekrar oynamak icin Enter tuþuna basýnýz...";
            kazanmaSesi.Play();
            Time.timeScale = 0f;

        }
        else if (player2skor == maxSkor)
        {
            kazananYazisi.text = "hümeyra kazandý!";
            bitisYazisi.text = "Tekrar oynamak icin Enter tuþuna basýnýz...";
            kazanmaSesi.Play();
            Time.timeScale = 0f;
        }

        
    }
}
