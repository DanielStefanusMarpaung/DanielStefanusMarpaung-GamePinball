using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{

    // menyimpan variabel bola sebagai referensi untuk pengecekan
	public Collider bola;

    // untuk mengatur kecepatan bola setelah memantul
    public float multiplier;

    // untuk mengatur warna bumper
    public Color color;

    // komponen renderer pada object yang akan diubah
    private Renderer renderer;

    // kita tambahkan reference animator
    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        renderer.material.color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // memastikan yang menabrak adalah bola
        if (collision.collider == bola)
        {
                // ambil rigidbody nya lalu kali kecepatannya sebanyak multiplier agar bisa memantul lebih cepat
                Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
                bolaRig.velocity *= multiplier;

                // saat ditabrak oleh bola, kita tinggal aktifkan trigger Hit
                animator.SetTrigger("hit");
        }
    }
}
