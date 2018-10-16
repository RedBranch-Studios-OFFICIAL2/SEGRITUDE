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

    private bool seePlayer;
    private int resetWarningCountDown;
    private float resetTimeForNextPoint;

    private Vector3 newpos;
    private GameObject player;


    private void Start() {
        this.resetTimeForNextPoint = this.timeForNextPoint;
        this.seePlayer = false;
        this.fovCollider = GetComponent<BoxCollider>();
        FieldOfView();
        this.resetWarningCountDown = this.warningCountDown;
    }

    private void Update() {
        ActionDecider();
    }

    void FieldOfView() {
        this.fovCollider.size = new Vector3(this.fovCollider.size.x, this.fovCollider.size.y, this.FOV);
        this.fovCollider.center = new Vector3(this.fovCollider.center.x, this.fovCollider.size.y, this.FOV / 2);
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            this.seePlayer = true;
            this.player = other.gameObject;
        }
    }

    void ActionDecider() {
        if (this.seePlayer) {
            GiveWarning();
        }
        if (!seePlayer) {
            Patrol();
        }
        if (CheckForGettingShot()) {
            //Say that it should take cover.
        }
        if (player != null) {
            if (PlayerDistanceChecking() >= minChaseDistance) {

            } else if (PlayerDistanceChecking() >= maxChaseDistance) {
                player = null;
            }
        }


    }
    float PlayerDistanceChecking() {
        float playerToDistance = Vector3.Distance(this.transform.position, this.player.transform.position);
        return playerToDistance;
    }

    bool CheckForGettingShot() {
        //Check if the AI is being shot at
        return true;
    }

    void GiveWarning() {
        this.warningCountDown -= (int)Time.deltaTime;
        this.warningText.text = "LEAVE: " + this.warningCountDown;
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
    void TakeCover() {
        Vector3 cover = ClosestCover();
        this.gameObject.GetComponent<NavMeshAgent>().SetDestination(cover);
        //Still needs something so that it goes to the opposite direction of the player
    }

    Vector3 ClosestCover() {
        Collider closestCover = null;
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

    #endregion
}
