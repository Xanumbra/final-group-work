using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Animation Controller
 * Singleton Class responsible for triggering animations for the end scene.
 */
public class AnimationController : MonoBehaviour
{
    // Singleton instance object
    public static AnimationController instance = null;

    public Animator animator;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Win");
        }
    }
}
