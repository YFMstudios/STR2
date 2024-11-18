using UnityEngine;

public class MinionRangedCombat : MonoBehaviour
{
    public GameObject projectilePrefab;       // Projecile prefab (ate�lenecek mermi)
    public Transform projectileSpawnPoint;    // Mermi spawn noktas�

    private float attackRange;                 // Sald�r� menzili
    private float attackDamage;                // Sald�r� hasar�
    public float attackCooldown = 1.0f;        // Sald�r� aral��� (cooldown)

    private float lastAttackTime;              // Son sald�r� zaman�

    private ObjectiveStats stats;              // Obje �zerindeki istatistikler bile�eni
    private MinionAI minionAI;                 // Minion hareket ve hedef y�netimi bile�eni

    private void Start()
    {
        stats = GetComponent<ObjectiveStats>();    // Obje �zerindeki istatistikler bile�eni al�n�r
        minionAI = GetComponent<MinionAI>();       // Minion hareket ve hedef y�netimi bile�eni al�n�r

        attackRange = minionAI.stopDistance + 0.5f; // Sald�r� menzili minion hareket bile�eninden al�n�r (stopDistance)
        attackDamage = stats.damage;                // Sald�r� hasar� istatistikler bile�eninden al�n�r
    }

    private void Update()
    {
        // Sald�r� cooldown s�resi kontrol�
        if (Time.time >= lastAttackTime + attackCooldown && IsTargetInRange())
        {
            Attack(); // Sald�r� ger�ekle�tir
        }
        else if (!IsTargetInRange())
        {
            minionAI.StopCombat(); // Hedefte de�ilse sava�� durdur
        }
    }

    private bool IsTargetInRange()
    {
        // Minion'un hedefi var m� ve hedef minion'un sald�r� menzilinde mi kontrol eder
        return minionAI.currentTarget != null && Vector3.Distance(transform.position, minionAI.currentTarget.position) <= attackRange;
    }

    private void Attack()
    {
        // Eger son saldiri dan sonra cooldown süresi dolmus ise
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time; // Son saldiri zamanini güncelle
            minionAI.StartCombat(); // Minion savasi baslatir

            // ProjectilePrefab'ten yeni bir mermi (projectile) olustur
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
            MinionRangedProjectile projectileScript = projectile.GetComponent<MinionRangedProjectile>();
            projectileScript.SetTarget(minionAI.currentTarget.gameObject, attackDamage); // Mermiye hedef ve saldiri hasari ata

            // Eger hedef oyuncuysa hasar verme islemi
            if (minionAI.currentTarget.CompareTag("Enemy"))
            {
                Stats playerStats = minionAI.currentTarget.GetComponent<Stats>();
                playerStats?.TakeDamage(gameObject, attackDamage); // Null check ile hasar verir
            }
        }
    }
}
