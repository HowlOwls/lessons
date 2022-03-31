using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] private int weaponSwitch = 0;
    public int weaponOpened = 2;
    public bool shotgunPickeUp = false;
    private void Start()
    {
        SelectWeapon();
    }
    private void Update()
    {
        WeaponSwith();
    }
    private void WeaponSwith()
    {
        int curWeapon = weaponSwitch;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weaponSwitch >= transform.childCount - weaponOpened)
                weaponSwitch = 0;
            else
            {
                weaponSwitch++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (weaponSwitch <= 0)
                weaponSwitch = transform.childCount - weaponOpened;
            else
                weaponSwitch--;
        }
        
      
        if (Input.GetKeyDown(KeyCode.Alpha1))
            weaponSwitch = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >=2)
            weaponSwitch = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3) && shotgunPickeUp == true)
            weaponSwitch = 2;
        if(curWeapon != weaponSwitch)
            SelectWeapon();
    }
    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform) // Смена оружия без смены позиции
        {
            if( i == weaponSwitch)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            
            i++;
        }
    }
    
}
