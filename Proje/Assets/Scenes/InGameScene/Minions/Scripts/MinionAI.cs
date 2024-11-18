using UnityEngine;
using UnityEngine.AI;

public class MinionAI : MonoBehaviour
{
    public Transform currentTarget;         // Mevcut hedef
    public string enemyTag;                 // Düşman player etiketi
    public string enemyMinionTag;           // Düşman minion etiketi
    public string turretTag;                // Kule etiketi
    public float stopDistance = 2.0f;       // Durma mesafesi
    public float aggroRange = 5.0f;         // Saldırı mesafesi
    public float targetSwitchInterval = 2.0f; // Hedef değiştirme aralığı
    public float rotationSpeed = 5f;        // Hedefe doğru dönme hızı
    public float attackCooldown = 1f;       // Saldırı bekleme süresi
    private float lastAttackTime;           // Son saldırı zamanı

    private NavMeshAgent agent;             // Navigasyon ajanı
    public bool IsInCombat { get; private set; } // Savaş durumunu belirtir (özellik)

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Navigasyon ajanı bileşeni alınır
        InvokeRepeating(nameof(FindAndSetTarget), 0f, targetSwitchInterval); // Hedefi belirleme metodu belirli aralıklarla çağrılır
    }

    private void Update()
    {
        if (currentTarget != null)
        {
            if (!IsInCombat)
            {
                MoveTowardsTarget(); // Hedefe doğru hareket etme
            }
            RotateTowardsTarget(); // Hedefe doğru dönme
        }
    }

    private void MoveTowardsTarget()
    {
        // Mevcut hedefe doğru hareket etme
        if (Vector3.Distance(transform.position, currentTarget.position) > stopDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(currentTarget.position);
        }
        else
        {
            agent.isStopped = true;
            StartCombat(); // Hedefe yaklaştığında savaşı başlat
        }
    }

    private void RotateTowardsTarget()
    {
        // Hedefe doğru dönme
        Vector3 directionToTarget = (currentTarget.position - transform.position).normalized;
        if (directionToTarget != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
    }

    public void StartCombat()
    {
        // Savaşı başlatma
        IsInCombat = true;
        agent.isStopped = true;
        Attack(); // Hedefe ulaştığında saldırıyı başlat
    }

    public void StopCombat()
    {
        // Savaşı durdurma
        IsInCombat = false;
        agent.isStopped = false;
    }

    private void FindAndSetTarget()
    {
        // Yakındaki hedefleri bul ve ayarla (enemy, düşman minion veya turret)
        Transform closestEnemy = FindClosestWithTagInRadius(enemyTag, aggroRange);
        Transform closestEnemyMinion = FindClosestWithTagInRadius(enemyMinionTag, aggroRange);
        Transform closestTurret = FindClosestWithTagInRadius(turretTag, aggroRange);

        // En yakın hedefi belirle (öncelik sırası: enemy minion, turret, player)
        Transform[] targets = new Transform[] { closestEnemyMinion, closestTurret, closestEnemy };
        currentTarget = GetClosestTarget(targets);
    }

    private Transform GetClosestTarget(Transform[] targets)
    {
        // Verilen hedefler arasında en yakını bul
        Transform closestTarget = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (Transform target in targets)
        {
            if (target != null) // Eğer hedef geçerliyse
            {
                float distance = Vector3.Distance(currentPosition, target.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTarget = target;
                }
            }
        }

        return closestTarget;
    }

    private Transform FindClosestWithTagInRadius(string tag, float radius)
    {
        // Belirli etikete sahip ve belirli bir yarıçap içindeki en yakın nesneyi bulma
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        return GetClosestObjectInRadius(objects, radius);
    }

    private Transform GetClosestObjectInRadius(GameObject[] objects, float radius)
    {
        // Verilen nesne dizisinde belirli bir yarıçap içindeki en yakın nesneyi bulma
        float closestDistance = Mathf.Infinity;
        Transform closestObject = null;
        Vector3 currentPosition = transform.position;

        foreach (GameObject obj in objects)
        {
            float distance = Vector3.Distance(currentPosition, obj.transform.position);
            if (distance < closestDistance && distance <= radius)
            {
                closestDistance = distance;
                closestObject = obj.transform;
            }
        }

        return closestObject;
    }

    private void Attack()
    {
        // Saldırıyı gerçekleştir
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;

            float damage = 2f;
            if (currentTarget.CompareTag("EnemyMinion")) // Düşman miniona saldırı
            {
                ObjectiveStats minionStats = currentTarget.GetComponent<ObjectiveStats>();
                if (minionStats != null)
                {
                    minionStats.TakeDamage(damage);
                }
            }
            else if (currentTarget.CompareTag("EnemyTurret")) // Düşman turret'e saldırı
            {
                ObjectiveStats turretStats = currentTarget.GetComponent<ObjectiveStats>();
                if (turretStats != null)
                {
                    turretStats.TakeDamage(damage);
                }
            }
            else if (currentTarget.CompareTag("Enemy")) // Düşman player'a saldırı
            {
                Stats enemyStats = currentTarget.GetComponent<Stats>();
                if (enemyStats != null)
                {
                    enemyStats.TakeDamage(gameObject, damage);
                }
            }
        }
    }
}
