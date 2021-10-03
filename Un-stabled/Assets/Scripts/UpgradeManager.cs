using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct Save {
    public int points;
    public List<int> unlockedUpgrades;

}

public class Upgrade {
    public int id;
    public string name;
    public string description;
    public int cost;
    public bool unlocked;
}


public class UpgradeManager : MonoBehaviour
{
    public List<Upgrade> upgrades = new List<Upgrade>() {
        new Upgrade() {id = 0, name = "Sugar Cubes",            cost = 50,  description="Speed Up"},
        new Upgrade() {id = 1, name = "Apples",                 cost = 75,  description="Healing"},
        new Upgrade() {id = 2, name = "Hey Protein",            cost = 100, description="Health Up"},
        new Upgrade() {id = 3, name = "Rosettes",               cost = 125, description="Dmg Up"},
        new Upgrade() {id = 4, name = "[Jump Height]",          cost = 100, description="Jump Height"},
        new Upgrade() {id = 5, name = "[!Bullet Speed Down]",   cost = 100, description="Enemy Bullet Speed Down"},
        new Upgrade() {id = 6, name = "[!Speed Down]",          cost = 100, description="Enemy Speed Down"},
        new Upgrade() {id = 7, name = "[!Fire Rate Down]",      cost = 100, description="Enemy Fire Rate Down"},
        new Upgrade() {id = 8, name = "[!Health Down]",         cost = 100, description="Enemy Health Down"},
        new Upgrade() {id = 9, name = "[Double Jump]",          cost = 100, description="Double Jump"},
        new Upgrade() {id =10, name = "[Faster Rage Charge]",   cost = 100, description="Faster Rage Charge"},
        new Upgrade() {id =11, name = "[Multishot]",            cost = 100, description="Multishot"},
        new Upgrade() {id =12, name = "[Longer Rage]",          cost = 100, description="Longer Range"},
    };
    private int _upgradePoints = 0;
    public int upgradePoints {
        get { return _upgradePoints;}
    }

    private void Awake() {
        // Load data
        Load();
    }

    private void OnDestroy() {
        Save();
    }

    public void Save() {
        Save save = new Save();
        save.points = _upgradePoints;

        save.unlockedUpgrades = upgrades.FindAll(x => x.unlocked).Select(x => x.id).ToList();

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
            foreach (Upgrade u in upgrades) {
                if (save.unlockedUpgrades.Contains(u.id)) {
                    u.unlocked = true;
                }
            }
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

    public bool Purchase(Upgrade item) {
        if (SpendPoints(item.cost)) {
            item.unlocked = true;
            return true;
        }
        return false;
    }

}
