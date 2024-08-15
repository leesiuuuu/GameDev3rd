using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BombThrow_Re : MonoBehaviour
{
    private Transform m_Target;
    public float m_InitialAngle = 30f; // 처음 날라가는 각도
    public float speedMultiplier = 1.0f; // 속도 조절 변수
    private Rigidbody2D m_Rigidbody;
    public GameObject DeathEffect;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Target = GameObject.FindWithTag("Player").transform;
        Vector3 velocity = GetVelocity(transform.position, m_Target.position, m_InitialAngle);
        m_Rigidbody.velocity = velocity;
    }
    public Vector3 GetVelocity(Vector3 player, Vector3 target, float initialAngle)
    {
        float gravity = Physics2D.gravity.magnitude;
        float angle = initialAngle * Mathf.Deg2Rad;

        Vector3 planarTarget = new Vector3(target.x, 0, target.z);
        Vector3 planarPosition = new Vector3(player.x, 0, player.z);

        float distance = Vector3.Distance(planarTarget, planarPosition);
        float yOffset = player.y - target.y;

        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));
        initialVelocity *= speedMultiplier;

        Vector3 velocity = new Vector3(0f, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPosition) * (target.x > player.x ? 1 : -1);
        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;

        return finalVelocity;
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Player_idel-Sheet_0"){
            Transform shield = collision.transform.Find("PencilShield");
            if (shield != null && shield.gameObject.activeSelf){
                Destroy(gameObject);
            }
            else{
                if(!player.GetComponent<PlayerMovement>().ShieldCheck){
                    collision.gameObject.GetComponent<PlayerAttakced>().enabled = true;
                    collision.gameObject.GetComponent<PlayerAttakced>().isAtked = true;
                    Destroy(this.gameObject);
                }
                else{
                    Destroy(gameObject);
                }                
            }
        }
        if(collision.gameObject.CompareTag("Ground")){
            Destroy(this.gameObject);
            Death();
        }
    }
    void Death(){
        GameObject clone = Instantiate(DeathEffect);
        clone.transform.position = new Vector3(transform.position.x, transform.position.y+1f, 19);
        Destroy(clone, 0.2f);
    }
}
