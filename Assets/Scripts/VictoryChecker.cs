using UnityEngine;
public class VictoryChecker : MonoBehaviour {
    public StackZone[] foundationZones;
    public UIManager uiManager;
    void Update() {
        bool allComplete = true;
        foreach (StackZone zone in foundationZones) {
            if (zone.cards.Count < 13) {
                allComplete = false;
                break;
            }
        }
        if (allComplete) {
            uiManager.ShowWin();
            enabled = false;
        }
    }
}