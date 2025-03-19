using UnityEngine;
using UnityEngine.UIElements;

public class PickupController : MonoBehaviour
{
    public int pickupValue = 10;

    private UIDocument uiHUD;
    private Label lblScoreValue;

    void Start()
    {
        uiHUD = GameObject.Find("HUD").GetComponent<UIDocument>();
        lblScoreValue = uiHUD.rootVisualElement.Query<Label>("ScoreValue");
    }

    void OnTriggerEnter(Collider other)
    {
        // get current score as integer
        int score = int.Parse(lblScoreValue.text);

        // add this pickup's value to score, then update the HUD score value
        lblScoreValue.text = (score + pickupValue).ToString();

        gameObject.SetActive(false);
    }
}
