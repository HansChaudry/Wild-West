using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{ 
    private float shootDelay = 0.2f;
    private float bulletSpeed = 3000f;
    private int magazine = 6;
    private float lastShot;

    public TMPro.TMP_Text magazineText;
    public GameObject bullet;
    public Transform bulletPosition;
    public AudioSource audioSource;
    public Animator animator;

    private void Start()
    {
        magazineText.text = magazine.ToString();
    }

    public void Shoot()
    {
        if (magazine > 0)
        {
            fireGun();
        }

        //flash the reload text
    }

    private void GunShotAudio()
    {
        var random = Random.Range(0.8f, 1.2f);
        audioSource.pitch = random;
        audioSource.Play();
    }

    private void fireGun()
    {
        if (lastShot > Time.time) return;
        lastShot = Time.time + shootDelay;
        animator.SetTrigger("Recoil");
        GunShotAudio();
        magazine -= 1;
        magazineText.text = magazine.ToString();

        var bulletPrefab = Instantiate(bullet, bulletPosition.position, bulletPosition.rotation);
        var bulletRB = bulletPrefab.GetComponent<Rigidbody>();
        var direction = bulletPrefab.transform.TransformDirection(Vector3.forward);

        bulletRB.AddForce(direction * bulletSpeed);
        Destroy(bulletPrefab, 5f);
    }

    private void reload()
    {
        magazine = 6;
        magazineText.text = magazine.ToString();
    }
}
