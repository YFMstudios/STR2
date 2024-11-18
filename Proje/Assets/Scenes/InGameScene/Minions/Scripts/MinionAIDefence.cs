using UnityEngine;
using UnityEngine.AI;

public class MinionAIDefence : MonoBehaviour
{
    public Transform currentTarget;             // Mevcut hedef
    public string enemyMinionTag;               // Dusman minion etiketi
    public string playerTag;                     // Player etiketi
    public float stopDistance = 2.0f;            // Durma mesafesi
    public float aggroRange = 5.0f;              // Saldiri mesafesi
    public float targetSwitchInterval = 2.0f;    // Hedef degistirme araligi
    public float rotationSpeed = 5f;             // Hedefe dogru donme hizi

    private NavMeshAgent agent;                  // Navigasyon ajani
    public bool IsInCombat { get; private set; } // Savas durumunu belirtir

    private float attackCooldown = 1f;           // Saldiri icin bekleme süresi
    private float lastAttackTime;                 // Son saldiri zamani

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Navigasyon ajani bileşeni alinir
        InvokeRepeating(nameof(FindAndSetTarget), 0f, targetSwitchInterval); // Hedef belirleme metodu belirli araliklarla çağrılır
    }

    private void Update()
    {
        if (currentTarget != null)
        {
            if (!IsInCombat)
            {
                MoveTowardsTarget(); // Hedefe dogru hareket etme
            }
            RotateTowardsTarget(); // Hedefe dogru donme
        }
    }

    private void MoveTowardsTarget()
    {
        // Mevcut hedefe dogru hareket etme
        if (Vector3.Distance(transform.position, currentTarget.position) > stopDistance)
        {
            agent.isStopped = false; // Ajan durdurulmaz
            agent.SetDestination(currentTarget.position); // Hedefe dogru hareket et
        }
        else
        {
            agent.isStopped = true; // Hedefe ulasildiginda ajani durdur
            Attack(); // Hedefe ulasildiginda saldir
        }
    }

    private void RotateTowardsTarget()
    {
        // Hedefe dogru donme
        Vector3 directionToTarget = (currentTarget.position - transform.position).normalized;
        if (directionToTarget != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed); // Dönme islemi
        }
    }

    public void StartCombat()
    {
        // Savas baslatma
        IsInCombat = true;
        agent.isStopped = true; // Ajan durdurulur
    }

    public void StopCombat()
    {
        // Savas durdurma
        IsInCombat = false;
        agent.isStopped = false; // Ajan devam eder
    }

    private void FindAndSetTarget()
    {
        // En yakin dusman minion ve oyuncu hedefini bul
        Transform closestEnemyMinion = FindClosestWithTagInRadius(enemyMinionTag, aggroRange);
        Transform closestPlayer = FindClosestWithTag(playerTag);

        // En yakin hedefi sec
        if (closestEnemyMinion != null && closestPlayer != null)
        {
            float distanceToEnemyMinion = Vector3.Distance(transform.position, closestEnemyMinion.position);
            float distanceToPlayer = Vector3.Distance(transform.position, closestPlayer.position);
            currentTarget = distanceToEnemyMinion < distanceToPlayer ? closestEnemyMinion : closestPlayer; // En yakin hedef
        }
        else
        {
            currentTarget = closestEnemyMinion ?? closestPlayer; // Null koalisyon
        }
    }

    private Transform FindClosestWithTag(string tag)
    {
        // Belirli etikete sahip en yakin nesneyi bul
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        return GetClosestObject(objects);
    }

    private Transform FindClosestWithTagInRadius(string tag, float radius)
    {
        // Belirli etikete sahip ve belirli bir yaricap icindeki en yakin nesneyi bul
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        return GetClosestObjectInRadius(objects, radius);
    }

    private Transform GetClosestObject(GameObject[] objects)
    {
        // Verilen nesne dizisinde en yakin nesneyi bul
        float closestDistance = Mathf.Infinity;
        Transform closestObject = null;
        Vector3 currentPosition = transform.position;

        foreach (GameObject obj in objects)
        {
            float distance = Vector3.Distance(currentPosition, obj.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance; // En yakin mesafeyi güncelle
                closestObject = obj.transform; // En yakin nesneyi ata
            }
        }

        return closestObject; // En yakin nesneyi döndür
    }

    private Transform GetClosestObjectInRadius(GameObject[] objects, float radius)
    {
        // Verilen nesne dizisinde belirli bir yaricap icindeki en yakin nesneyi bul
        float closestDistance = Mathf.Infinity;
        Transform closestObject = null;
        Vector3 currentPosition = transform.position;

        foreach (GameObject obj in objects)
        {
            float distance = Vector3.Distance(currentPosition, obj.transform.position);
            if (distance < closestDistance && distance <= radius)
            {
                closestDistance = distance; // En yakin mesafeyi güncelle
                closestObject = obj.transform; // En yakin nesneyi ata
            }
        }

        return closestObject; // En yakin nesneyi döndür
    }

    private void Attack()
    {
        // Saldiriyi gerçekleştir
        if (Time.time >= lastAttackTime + attackCooldown) // Bekleme süresi kontrolü
        {
            lastAttackTime = Time.time; // Son saldiri zamanini güncelle

            float damage = 2f; // Hasar miktari
            if (currentTarget.CompareTag("Player")) // Eğer hedef oyuncuysa
            {
                Stats playerStats = currentTarget.GetComponent<Stats>();
                playerStats.TakeDamage(gameObject, damage); // Null kontrol ile hasar verir
            }
            else if (currentTarget.CompareTag("EnemyMinion")) // Eğer hedef minion ise (enemy minion)
            {
                ObjectiveStats minionStats = currentTarget.GetComponent<ObjectiveStats>();
                if (minionStats != null) // Eğer minion ObjectiveStats component'ine sahipse
                {
                    minionStats.TakeDamage(damage); // Hasarı uygula
                }
            }
        }
    }

}
