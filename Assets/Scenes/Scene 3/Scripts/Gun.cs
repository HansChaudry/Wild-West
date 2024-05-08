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
    public AudioSource fireSound;
    public AudioSource emptyFireSound;
    public AudioSource reloadSound;
    public Animator animator;

    private void Start()
    {
        magazineText.text = magazine.ToString();
        magazineText.alignment = TMPro.TextAlignmentOptions.Center;
    }

    public void Shoot()
    {
        if (magazine > 0)
        {
            fireGun();
        }else{
            magazineText.text = "Reload";
            magazineText.alignment = TMPro.TextAlignmentOptions.Left;
            magazineText.color = Color.red;
        }

        //flash the reload text
    }

    private void GunShotAudio()
    {
        var random = Random.Range(0.8f, 1.2f);
        fireSound.pitch = random;
        fireSound.Play();
    }

    private void emptyFireAudio()
    {
        var random = Random.Range(0.8f, 1.2f);
        emptyFireSound.pitch = random;
        emptyFireSound.Play();
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
        reloadSound.Play();
        magazine = 6;
        magazineText.text = magazine.ToString();
        magazineText.alignment = TMPro.TextAlignmentOptions.Center;
        magazineText.color = Color.white;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("ReloadPack"))
        {
            reload();
        }
    }


}
