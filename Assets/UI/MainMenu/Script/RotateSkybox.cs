using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    public float m_rotationSpeed = 1f;
    private float m_rotation;

    void Update()
    {
        if (RenderSettings.skybox == null)
            return;

        m_rotation += m_rotationSpeed * Time.unscaledDeltaTime;
        m_rotation %= 360f;

        RenderSettings.skybox.SetFloat("_Rotation", m_rotation);
    }
}
