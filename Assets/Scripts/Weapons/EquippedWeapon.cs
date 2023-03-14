using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedWeapon : MonoBehaviour
{
    private GameObject player;

    private GameObject weaponGroup;
    private Dictionary<string, GameObject> weaponList = new Dictionary<string, GameObject>();

    private GameObject plusWeapon;
    private GameObject minusWeapon;
    private GameObject multiplyWeapon;
    private GameObject divideWeapon;
    
    private SpriteRenderer weaponRender;
    private Vector3 offset;

    /// <summary>
    /// Start is called before the first frame update
    /// This sets up the dictionary used to get which weapon to use.
    /// It also grabs the Game Objects of each weapon and the player
    /// and sets their offset to be a little away from the Player.
    /// </summary>
    void Start()
    {
        player = new GameObject("Player");

        weaponGroup = GameObject.Find("Weapons");

        plusWeapon = GameObject.Find("PlusWeapon");
        minusWeapon = GameObject.Find("MinusWeapon");
        multiplyWeapon = GameObject.Find("MultiplyWeapon");
        divideWeapon = GameObject.Find("DivideWeapon");
        
        offset = transform.position - player.transform.position;

        weaponList.Add("nothing", null);
        weaponList.Add("plus", plusWeapon);
        weaponList.Add("minus", minusWeapon);
        weaponList.Add("multiply", multiplyWeapon);
        weaponList.Add("divide", divideWeapon);
        
        // weaponRenders = weaponGroup.GetComponentInChildren<SpriteRenderer>();
        // Debug.Log(weaponRenders);
        // weaponRenders.enabled = false;

        foreach (var weapon in weaponList)
        {
            Debug.Log($"weapon: {weapon.Value}");
            if (weapon.Value == null)
            {
                continue;
            }
            
            weaponRender = weapon.Value.GetComponent<SpriteRenderer>();
            Debug.Log($"weaponRender: {weaponRender}");
            if (weaponRender != null)
            {
                weaponRender.enabled = false;
            }
            //Debug.Log($"No Render found for {weapon.Value}");
        }
        
    }

    /// <summary>
    /// Runs after Update to handle fixing the position 
    /// of the weapons to stick with the player
    /// </summary>
    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
