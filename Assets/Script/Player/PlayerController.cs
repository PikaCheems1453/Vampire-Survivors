using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }

    public float moveSpeed = 2f;
    private Animator anim;

    public float pickupRange = 1;
    public bool isHit;

    //public Weapon activeWeapon;

    public List<Weapon> unassignedWeapons,assignWeapons;

    public int maxWeapons = 3;

    [HideInInspector]
    public List<Weapon> fullyLevelledWeapons = new List<Weapon>();

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        if(assignWeapons.Count == 0)
        {
            AddWeapon(Random.Range(0,unassignedWeapons.Count));
        }

        moveSpeed = PlayerStatController.instance.moveSpeed[0].value;
        pickupRange = PlayerStatController.instance.pickupRange[0].value;
        maxWeapons = Mathf.RoundToInt(PlayerStatController.instance.maxWeapons[0].value);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        //Debug.Log(moveInput);

        moveInput.Normalize();

        transform.position += moveInput * moveSpeed * Time.deltaTime;

        anim.SetBool("isMoving", moveInput != Vector3.zero);
        anim.SetFloat("Speed", Vector3.Distance(moveInput*moveSpeed, Vector3.zero));
        anim.SetFloat("Look X", moveInput.x);
        anim.SetFloat("Look Y", moveInput.y);
        if (isHit)
        {
            anim.SetTrigger("Hit");
        }
    }

    public void AddWeapon(int weaponNumber)
    {
        if(weaponNumber < unassignedWeapons.Count)
        {
            assignWeapons.Add(unassignedWeapons[weaponNumber]);
            unassignedWeapons[weaponNumber].gameObject.SetActive(true);
            unassignedWeapons.RemoveAt(weaponNumber);
        }
    }

    public void AddWeapon(Weapon weaponToAdd)
    {
        weaponToAdd.gameObject.SetActive(true);

        assignWeapons.Add(weaponToAdd);

        unassignedWeapons.Remove(weaponToAdd);
    }
}
