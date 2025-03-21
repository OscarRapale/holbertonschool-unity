using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject timerCanvas;
    public PlayerController playerController;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Make sure the cutscene animation plays
        animator.Play("Intro01");
    }

    void Update()
    {
        // Check if animation is finished
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !animator.IsInTransition(0))
        {
            EndCutscene();
        }
    }

    void EndCutscene()
    {
        // Enable Main Camera, Player Controller, and Timer Canvas
        mainCamera.SetActive(true);
        playerController.enabled = true;
        timerCanvas.SetActive(true);

        // Disable CutsceneCamera and CutsceneController
        gameObject.SetActive(false);
    }
}
