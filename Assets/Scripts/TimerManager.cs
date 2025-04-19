using UnityEngine;
using UnityEngine.UI;
public class TimerManager : MonoBehaviour {
    public Text timerText;
    private float timeElapsed = 0f;
    private bool running = true;
    void Update() {
        if (!running) return;
        timeElapsed += Time.deltaTime;
        int mins = Mathf.FloorToInt(timeElapsed / 60f);
        int secs = Mathf.FloorToInt(timeElapsed % 60f);
        timerText.text = $"{mins:00}:{secs:00}";
    }
    public void StopTimer() => running = false;
}