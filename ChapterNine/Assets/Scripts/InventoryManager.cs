﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager {
    public ManagerStatus status { get; private set; }
    public string equippedItem { get; private set; }

    private Dictionary<string, int> _items;

    public void Startup() {
        Debug.Log("inventory");
        _items = new Dictionary<string, int>();
        status = ManagerStatus.Started;
    }

    private void DisPlayItems() {
        string itemDisplay = "Items:";
        foreach (KeyValuePair<string, int> item in _items) {
            itemDisplay += item.Key + "( " + item.Value + ")";
        }
        Debug.Log(itemDisplay);
    }

    public void AddItem(string name) {
        if (_items.ContainsKey(name)) {
            _items[name] += 1;
        } else {
            _items[name] = 1;
        }

        DisPlayItems();
    }

    public List<string> GetItemList() {
        List<string> list = new List<string>(_items.Keys);
        return list;
    }

    public int GetItemCount(string name) {
        if (_items.ContainsKey(name)) {
            return _items[name];
        }

        return 0;
    }

    public bool EquipItem(string name) {
        if(_items.ContainsKey(name) && equippedItem != name) {
            equippedItem = name;
            Debug.Log("Equipped" + name);
            return true;
        }

        equippedItem = null;
        Debug.Log("Unequipped");
        return false;
    }
}
