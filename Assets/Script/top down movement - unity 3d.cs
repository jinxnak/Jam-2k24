using UnityEngine;
using UnityEngine.AI;

public class TopDownMovement : MonoBehaviour {

    private Rigidbody rb;
    [SerializeField] private float movementSpeed;
    private Vector3 axisInput;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        axisInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if (axisInput.magnitude > 0.1f)
        {
            Quaternion rotation = Quaternion.LookRotation(axisInput);
            transform.rotation = rotation;
        }
        /*if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                //navMeshAgent.SetDestination(hit.point);
            }
        }*/
    }

    /*private void FixedUpdate() {
        rb.velocity = axisInput * movementSpeed;
    }*/
}
