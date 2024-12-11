using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody rb; // Rigidbody of character
    private Animator animator; // Animator for animations

    // List of all possible animation states
    private List<string> stateNames = new List<string> {
        "Front_Idle_Stand",
        "Back_Idle_Stand",
        "Front_Walk",
        "Back_Walk",
        "Front_Idle_Sit",
        "Back_Idle_Sit"
    };

    // TODO: Add more animations to the list
    // TODO: There is no walk animation for facing back and walking to the left
    // TODO: There is no idle animation for facing back and looking to the left
    // TODO: There is no walk animation for facing front and walking to the right
    // TODO: There is no idle animation for facing front and looking to the right

    // Suggestion for additional animations:
    /*
    private List<string> stateNames = new List<string>{
        // Idle Animations
        "Front_Idle_Stand_Left",
        "Front_Idle_Stand_Right",
        "Back_Idle_Stand_Left",
        "Back_Idle_Stand_Right",

        // Walk Animations
        "Front_Walk_Left",
        "Front_Walk_Right",
        "Back_Walk_Left",
        "Back_Walk_Right",

        // Other Animations
        "Front_Sit",
        "Front_Idle_Sit",
        "Back_Sit",
        "Back_Idle_Sit"
    };
    */

    private string currentState; // Currently playing animation
    private Vector3 moveDirection; // Movement direction of character
    private bool isFacingRight = true; // Current facing direction of character (true = right, false = left)


    void Start() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        // Get input for movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        // Set facing direction
        if (moveX > 0) {
            isFacingRight = true;
        } else if (moveX < 0) {
            isFacingRight = false;
        }

        // TODO: Link the new animations to the input (for example like in the commented code below)

        // Play animations based on input
        if (moveDirection != Vector3.zero) {
            if (moveZ > 0) {
                // PlayAnimation(isFacingRight ? "Back_Walk_Right" : "Back_Walk_Left");
                PlayAnimation("Back_Walk");
            } else {
                // PlayAnimation(isFacingRight ? "Front_Walk_Right" : "Front_Walk_Left");
                PlayAnimation("Front_Walk");
            }
        } else {
            if (currentState.Contains("Back")) {
                // PlayAnimation(isFacingRight ? "Back_Idle_Stand_Right" : "Back_Idle_Stand_Left");
                PlayAnimation("Back_Idle_Stand");
            } else {
                // PlayAnimation(isFacingRight ? "Front_Idle_Stand_Right" : "Front_Idle_Stand_Left");
                PlayAnimation("Front_Idle_Stand");
            }
        }
    }

    private void FixedUpdate() {
        // Move character
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }


    /// <summary>
    /// Play animation based on the new state.
    /// </summary>
    /// <param name="newState">New animation state to play</param>
    private void PlayAnimation(string newState) {
        // Return if the new animation is the same as the current one
        if (currentState == newState) {
            return;
        }

        // Play new animation if it exists in the list
        if (stateNames.Contains(newState)) {
            animator.Play(newState);
            currentState = newState;
        } else {
            Debug.LogWarning($"Animation '{newState}' existiert nicht in der Liste.");
        }
    }
}