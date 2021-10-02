using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct Save {
    public int points;

}

public class UpgradeManager : MonoBehaviour
{
    private int _upgradePoints = 0;
    public int upgradePoints {
        get { return _upgradePoints;}
    }

    private void Awake() {
        // Load data
        Load();
    }

    private void Start() {
        if (SceneManager.GetActiveScene().name == "MainScene") {
            Canvas canvas = FindObjectOfType<Canvas>();

            for (int i = 0; i < 3; i++)
            {
                GameObject upgrade = Instantiate(Resources.Load("UpgradeItemPrefab")) as GameObject;
                upgrade.transform.SetParent(canvas.transform);
                upgrade.GetComponent<UpgradeItem>().itemName = "Test Code";
                upgrade.GetComponent<UpgradeItem>().itemCost = 100 * i;
                upgrade.transform.localPosition = new Vector3(-250, 140-70*i, 0);
                upgrade.SetActive(true);
            }
        }
    }

    private void OnDestroy() {
        Save();
    }

    public void Save() {
        Save save = new Save();
        save.points = _upgradePoints;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
    }

    public void Load() {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            _upgradePoints = save.points;
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) AddPoints(1);
        if (Input.GetKeyDown(KeyCode.DownArrow)) SpendPoints(1);
    }

    public void AddPoints(int points) {
        _upgradePoints += points;
    }

    public bool SpendPoints(int points) {
        if (points > upgradePoints) return false;
        _upgradePoints -= points;
        return true;
    }

}
