using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private float shootDelay = 0.2f;
    [Range(0, 3000), SerializeField] private float bulletSpeed;
    [Space, SerializeField] private AudioSource audioSource;

    private float lastShot;
    public Animator animator;


    public void Shoot()
    {
        if (lastShot > Time.time) return;
        lastShot = Time.time + shootDelay;
        animator.SetTrigger("Recoil");
        GunShotAudio();

        var bulletPrefab = Instantiate(bullet, bulletPosition.position, bulletPosition.rotation);
        var bulletRB = bulletPrefab.GetComponent<Rigidbody>();
        var direction = bulletPrefab.transform.TransformDirection(Vector3.forward);

        bulletRB.AddForce(direction * bulletSpeed);
        Destroy(bulletPrefab, 5f);
    }

    private void GunShotAudio()
    {
        var random = Random.Range(0.8f, 1.2f);
        audioSource.pitch = random;
        audioSource.Play();
    }
}
