using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet_;
    [SerializeField] private GameObject flash_;
    [SerializeField] private float cooldown_;
    private float internalCD = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && internalCD <= 0)
        {
            //Vector2 mousedir = (Input.mousePosition - this.transform.position).normalized;
            GameObject bullet = Instantiate(bullet_, this.transform.position, this.transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.MoveTowards(bullet.transform.position, Input.mousePosition, 1));
            StartCoroutine(MuzzleFlash());

            internalCD = cooldown_;
        }

        if (internalCD > 0 && internalCD != 0)
            internalCD -= Time.deltaTime;
    }

    IEnumerator MuzzleFlash()
    {
        flash_.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        flash_.SetActive(false);
        yield break;
    }
}