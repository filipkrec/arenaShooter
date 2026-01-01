using UnityEngine;
using UnityEngine.AI;

public static class NavMeshUtils
{
    public static bool CanReach(Vector3 _start, Vector3 _destination, int _areaMask = NavMesh.AllAreas)
    {
        NavMeshPath path = new NavMeshPath();

        bool pathFound = NavMesh.CalculatePath(
            _start,
            _destination,
            _areaMask,
            path
        );

        return pathFound && path.status == NavMeshPathStatus.PathComplete;
    }
}
