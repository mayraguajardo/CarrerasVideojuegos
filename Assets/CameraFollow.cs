using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float distance;
    public float height;
    public float damping;
    public bool smoothRotation;
    public bool followBehind;
    public float rotationDamping;
    void Start(){
        distance = 3.0f;
        height = 3.0f;
        damping = 5.0f;
        smoothRotation = true;
        followBehind = true;
        rotationDamping = 10.0f;
    }
    void Update(){
        Vector3 wantedPosition;
        if(followBehind)
            wantedPosition = target.TransformPoint(0, height, -distance);
        else
          wantedPosition = target.TransformPoint(0, height, distance);

        transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);

        if (smoothRotation) {
            Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
            //Quaternion ownRotation = Quaternion.RotateTowards;
            transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
        }
        else transform.LookAt (target, target.up);
    }
}