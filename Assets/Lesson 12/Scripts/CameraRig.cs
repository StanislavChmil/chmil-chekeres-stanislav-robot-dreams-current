using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float height = 2.0f;
    public float rotationSpeed = 3.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

  void Start()
  {
      yaw = target.eulerAngles.y;
      pitch = 15.0f;
  
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
  
      Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
      
      Vector3 position = target.position - (rotation * Vector3.forward * distance) 
                         + Vector3.up * height 
                         + target.right * 1.0f; 
  
      transform.position = position;
      transform.LookAt(target.position + Vector3.up * 1.5f);
  }

   void LateUpdate()
   {
       if (target == null) return;
   
      
       yaw += Input.GetAxis("Mouse X") * rotationSpeed;
       pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
       pitch = Mathf.Clamp(pitch, -20, 60);
   
      
       Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
       Vector3 position = target.position - (rotation * Vector3.forward * distance) + Vector3.up * height;
   
       transform.position = position;
       transform.LookAt(target.position + Vector3.up * 1.0f);
   
       Vector3 targetRotation = new Vector3(0, yaw, 0);
       target.rotation = Quaternion.Euler(targetRotation);
   }

}
