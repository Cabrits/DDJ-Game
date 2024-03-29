using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour, IHealth<int>{

    public int maxHealth;
    public int currentHealth;

    void Start(){
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageTaken){
        currentHealth -= damageTaken;

        if(currentHealth <= 0){
            Kill();
        }
    }

    public void HealDamage(int damageHealed){
        if((currentHealth + damageHealed) >= maxHealth){
            currentHealth = maxHealth;
        } else {
            currentHealth += damageHealed;
        }
    }

    public void Kill(){
        if(gameObject.GetComponent<PlayerAim>()){
            SceneManager.LoadScene(5);
        }else{
            GameObject.Find("Managers").GetComponent<RoundManager>().KilledEnemy(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
