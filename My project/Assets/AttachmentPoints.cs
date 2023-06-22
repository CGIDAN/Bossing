using UnityEngine;
public class AttachmentPoints : MonoBehaviour
{
    public GameObject vulnerableArea;
    public Transform[] attachmentPoints;

    private int shotCount = 0;

    public void Shoot()
    {
        shotCount++;

        if (shotCount >= 3)
        {
            // Generate a random attachment point index
            int randomIndex = Random.Range(0, attachmentPoints.Length);

            // Move the vulnerable area to the selected attachment point
            vulnerableArea.transform.SetParent(attachmentPoints[randomIndex]);
            vulnerableArea.transform.localPosition = Vector3.zero;
            vulnerableArea.transform.localRotation = Quaternion.identity;

            // Reset the shot count
            shotCount = 0;
        }
    }
}