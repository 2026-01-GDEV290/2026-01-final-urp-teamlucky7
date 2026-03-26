using UnityEngine;

public class RouletteBoardPlacer : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject betChipPrefab;
    public LayerMask boardLayerMask;
    public LayerMask chipLayerMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaceBet();
        }
        if (Input.GetMouseButtonDown(1))
        {
            RemoveBet();
        }
    }

    void PlaceBet()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, boardLayerMask))
        {
            Vector3 spawnPos = hit.point;
            spawnPos.y += 0.05f;

            GameObject chipObj = Instantiate(betChipPrefab, spawnPos, Quaternion.identity);
            BettingChip chip = chipObj.GetComponent<BettingChip>();

            if (chip != null)
            {
                chip.ResolvePlacement();
            }
        }
    }

    void RemoveBet()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, chipLayerMask))
        {
            BettingChip chip = hit.collider.GetComponentInParent<BettingChip>();

            if (chip != null)
            {
                chip.RemoveBet();
            }
        }
    }
}