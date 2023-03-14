using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class SignController : MonoBehaviour
{
    public GameObject signBoard;
    public bool startActive = true;
    public PlayerInput playerInput;

    private GameObject signPromptObjectText;
    private GameObject signPromptObjectTextBackground;
    private TextMeshProUGUI signText;
    private Image signTextBackground;
    private SpriteRenderer signBoardRender;
    private bool isTouching;
    
    /// <summary>
    /// Sets up the PlayerInput Component so that
    /// signs can be opened with the Use key.
    /// </summary>
    private void Awake()
    {
        playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
        playerInput.actions["Use"].started += context => OnUse(context); 
    }

    /// <summary>
    /// Start is called before the first frame update.
    /// This Start function sets up the text that appears when
    /// in front of a sign and makes any signs with startActive
    /// enabled be visible.
    /// </summary>
    void Start()
    {
        signPromptObjectText = GameObject.Find("SignPromptText");
        signPromptObjectTextBackground = GameObject.Find("SignPromptTextBackground");
        signText = signPromptObjectText.GetComponent<TextMeshProUGUI>();
        signTextBackground = signPromptObjectTextBackground.GetComponent<Image>();

        signText.enabled = false;
        signTextBackground.enabled = false;

        signBoardRender = signBoard.GetComponent<SpriteRenderer>();
        signBoardRender.enabled = false;

        if (startActive)
        {
            signBoardRender.enabled = true;
        }
    }

    /// <summary>
    /// Called when the player enters the
    /// trigger of the sign sprite.
    /// It enables the prompt that appears to 
    /// tell the player to use the Use key to
    /// open the sign.
    /// </summary>
    void OnTriggerEnter2D()
    {
        signPromptObjectText = GameObject.Find("SignPromptText");
        signPromptObjectTextBackground = GameObject.Find("SignPromptTextBackground");
        signText = signPromptObjectText.GetComponent<TextMeshProUGUI>();
        signTextBackground = signPromptObjectTextBackground.GetComponent<Image>();

        signText.enabled = true;
        signTextBackground.enabled = true;

        isTouching = true;
    }

    /// <summary>
    /// Called when the Player leaves the
    /// trigger of the sign sprite.
    /// Closed the sign prompt.
    /// </summary>
    void OnTriggerExit2D()
    {
        signPromptObjectText = GameObject.Find("SignPromptText");
        signPromptObjectTextBackground = GameObject.Find("SignPromptTextBackground");
        signText = signPromptObjectText.GetComponent<TextMeshProUGUI>();
        signTextBackground = signPromptObjectTextBackground.GetComponent<Image>();

        signText.enabled = false;
        signTextBackground.enabled = false;

        signBoardRender = signBoard.GetComponent<SpriteRenderer>();
        signBoardRender.enabled = false;

        isTouching = false;
    }

    /// <summary>
    /// Called when the user presses
    /// the Use key to open the sign.
    /// </summary>
    /// <param name="context"></param>
    public void OnUse(InputAction.CallbackContext context)
    {
        if (isTouching)
        {
            signBoardRender = signBoard.GetComponent<SpriteRenderer>();
            signBoardRender.enabled = true;
        }
    }
}
