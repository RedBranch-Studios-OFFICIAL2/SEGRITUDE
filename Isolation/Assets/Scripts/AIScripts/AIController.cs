using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class AIController : MonoBehaviour {

    public float minChaseDistance;
    public float maxChaseDistance;
    public float FOV;
    public float coverRadius;

    public float timeForNextPoint;
    public int warningCountDown;

    public Text warningText;
    public GameObject area;
    public LayerMask coverLayer;

    private BoxCollider fovCollider;

    public bool seePlayer;
    public bool isGettingShot;
    private int resetWarningCountDown;
    private float resetTimeForNextPoint;

    private Vector3 newpos;
    public GameObject player;
    private Rigidbody rbAI;
    private NavMeshAgent AIAgent;

    //animation conditions
    Animator anim;
    private bool isPatrolling;


    private void Start() {
        this.resetTimeForNextPoint = this.timeForNextPoint;
        this.seePlayer = false;
        this.fovCollider = GetComponent<BoxCollider>();
        this.FieldOfView();
        this.resetWarningCountDown = this.warningCountDown;
        this.isPatrolling = false;
        this.anim = GetComponent<Animator>();
        this.rbAI = GetComponent<Rigidbody>();
        this.AIAgent = this.GetComponent<NavMeshAgent>();
        this.isGettingShot = false;
    }

    private void Update() {
        ActionDecider();
        AnimationDecider();
    }

    void FieldOfView() {
        this.fovCollider.size = new Vector3(this.fovCollider.size.x, this.fovCollider.size.y, this.FOV);
        this.fovCollider.center = new Vector3(this.fovCollider.center.x, this.fovCollider.center.y, this.FOV / 2);
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            this.seePlayer = true;
            this.player = other.gameObject;
        }
        if (other.gameObject.tag == "Bullet") {
            this.isGettingShot = true;
        }
    }

    void ActionDecider() {
        //if (this.seePlayer && warningCountDown == resetWarningCountDown) {
            //GiveWarning();
       // }
        if (!seePlayer) {
            Patrol();
        }
        if (isGettingShot) {
            TakeCover();
        }
        if (this.seePlayer && warningCountDown <= 0) {
            WarningShot();
        }

        if (player != null) {
            if (PlayerDistanceChecking() >= minChaseDistance) {
                Chase();
            } else if (PlayerDistanceChecking() >= maxChaseDistance) {
                player = null;
            }
        }

    }

    void AnimationDecider() {
        if (AIAgent.velocity.magnitude <= 0f) {
            anim.SetBool("Patrolling", false);
        } else {
            anim.SetBool("Patrolling", true);
        }
    }

    float PlayerDistanceChecking() {
        float playerToDistance = Vector3.Distance(this.transform.position, this.player.transform.position);
        return playerToDistance;
    }

    //void GiveWarning() {
    //    this.warningCountDown -= (int)Time.deltaTime;
    //    this.warningText.text = "LEAVE: " + this.warningCountDown;
   // }

    void WarningShot() {
        //Shoot once somewhere random which is not at the player
    }

    #region Patrolling

    Vector3 RandomPointInArea(Transform enemy, Vector3 center, Vector3 size) {
        Vector3 randomDirection = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        NavMeshHit hit;

        NavMesh.SamplePosition(randomDirection, out hit, 10, NavMesh.AllAreas);

        return hit.position;
    }

    void Patrol() {

        this.timeForNextPoint -= Time.deltaTime;

        if (!gameObject.GetComponent<NavMeshAgent>().pathPending && gameObject.GetComponent<NavMeshAgent>().remainingDistance < 0.5f && !seePlayer) {
            if (this.timeForNextPoint < 0) {
                newpos = RandomPointInArea(this.transform, this.area.transform.position, this.area.transform.localScale);

                timeForNextPoint = resetTimeForNextPoint;
            }
        }
        gameObject.GetComponent<NavMeshAgent>().SetDestination(this.newpos);
    }


    #endregion

    #region Cover
    Collider closestCover;
    Vector3 correctCover;
    void TakeCover() {
        Vector3 cover = ClosestCover();
        if (player != null) {
            LookForPlayer();
        }
         correctCover = CheckCoverSide();
        this.gameObject.GetComponent<NavMeshAgent>().SetDestination(correctCover);
        
        
    }

    void LookForPlayer() {
        Ray toPlayer = new Ray(this.transform.position, player.transform.position);
        RaycastHit playerHit;
        this.transform.LookAt(player.transform);

        if (Physics.Raycast(toPlayer, out playerHit)) {
            if (playerHit.collider.tag == "Player") {
                CheckCoverSide();
            }
        }
    }

    Vector3 CheckCoverSide() {
        Vector3 oppositeSide = closestCover.transform.localScale + this.transform.position;
        if (correctCover == null) {
            return oppositeSide;
        } else
            return correctCover;
        
        
    }

    Vector3 ClosestCover() {
        
        //Get all Colliders of the covers in the area;
        Collider[] coverColliders = Physics.OverlapSphere(this.transform.position, this.coverRadius, this.coverLayer);

        //Get the distance to the closest cover
        float distanceToClosestCover = Mathf.Infinity;

        foreach (Collider coverCollider in coverColliders) {
            // Calculate the distance to the cover
            float distanceToCover = (coverCollider.transform.position - this.transform.position).sqrMagnitude;
            //Check if it is the closest cover
            if (distanceToCover < distanceToClosestCover) {
                distanceToClosestCover = distanceToCover;
                closestCover = coverCollider;
            }
        }
        float closeToCover = Vector3.Distance(this.transform.position, closestCover.transform.position);

        if (closestCover != null) {
            return closestCover.transform.position;
        } else if (closeToCover <= 5) {
            return this.transform.position;
        } else {
            return this.transform.position;
        }

    }
    #endregion

    #region Chase
    void Chase() {

    }
    #endregion
}
