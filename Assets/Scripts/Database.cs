using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Database : MonoBehaviour {

    public List<Item> itemDataBase = new List<Item>();
    public List<Character> characterDataBase = new List<Character>();

    private JSONObject itemData, characterData;

    private void Start()
    {
        itemData = new JSONObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        characterData = new JSONObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Characters.json"));

        ConstructItemDatabase(itemData);
        ConstructCharacterDatabase(characterData);
        foreach (Character character in characterDataBase) //temporal
        {
            character.gun = itemDataBase[0];
        }
    }



    public Item getItemById(int id)
    {
        for (int i = 0; i < itemDataBase.Count; i++)
        {
            if (itemDataBase[i].ID == id)
                return itemDataBase[i];
        }
        return null;
    }
    public Character getCharacterById(int id)
    {
        for (int i = 0; i < characterDataBase.Count; i++)
        {
            if (characterDataBase[i].ID == id)
                return characterDataBase[i];
        }
        return null;
    }

    void ConstructItemDatabase(JSONObject obj)
    {
        switch (obj.type)
        {
            case JSONObject.Type.OBJECT:
                for (int i = 0; i < obj.list.Count; i++)
                {
                    string key = (string)obj.keys[i];
                    JSONObject j = (JSONObject)obj.list[i];
                    //Debug.Log(obj["id"]);
                    ConstructItemDatabase(j);
                }
                itemDataBase.Add(new Item(obj["id"].n,
                                        obj["damage"].n,
                                        obj["speed"].n,
                                        obj["range"].n,
                                        obj["criticalValue"].n,
                                        obj["criticalChance"].n
                                        ));


                break;
            case JSONObject.Type.ARRAY:
                foreach (JSONObject j in obj.list)
                {
                    ConstructItemDatabase(j);
                }
                break;
            case JSONObject.Type.STRING:
                //Debug.Log(obj.str);
                break;
            case JSONObject.Type.NUMBER:
                //Debug.Log(obj.n);
                break;
            case JSONObject.Type.BOOL:
                //Debug.Log(obj.b);
                break;
            case JSONObject.Type.NULL:
                //Debug.Log("NULL");
                break;
        }
    }
    private void ConstructCharacterDatabase(JSONObject characterData)
    {
        switch (characterData.type)
        {
            case JSONObject.Type.OBJECT:
                for (int i = 0; i < characterData.list.Count; i++)
                {
                    string key = (string)characterData.keys[i];
                    JSONObject j = (JSONObject)characterData.list[i];
                    //Debug.Log(characterData["id"]);
                    ConstructItemDatabase(j);
                }
                characterDataBase.Add(new Character(characterData["id"].n,
                                        characterData["hp"].n,
                                        characterData["acc"].n,
                                        characterData["strenght"].n,
                                        characterData["power"].n,
                                        characterData["criticalChance"].n,
                                        characterData["agility"].n,
                                        characterData["shield"].n,
                                        characterData["name"].str));


                break;
            case JSONObject.Type.ARRAY:
                foreach (JSONObject j in characterData.list)
                {
                    ConstructCharacterDatabase(j);
                }
                break;
            case JSONObject.Type.STRING:
                //Debug.Log(obj.str);
                break;
            case JSONObject.Type.NUMBER:
                //Debug.Log(obj.n);
                break;
            case JSONObject.Type.BOOL:
                //Debug.Log(obj.b);
                break;
            case JSONObject.Type.NULL:
                //Debug.Log("NULL");
                break;
        }
    }
}

public class Item
{
    public float ID { get; set; }
    public float damage { get; set; }
    public float speed { get; set; }
    public float range { get; set; }
    public float criticalValue { get; set; }
    public float criticalChance { get; set; }

    public Item(float id, float damage, float speed, float range, float criticalValue, float criticalChance)
    {
        this.ID = id;
        this.damage = damage;
        this.speed = speed;
        this.range = range;
        this.criticalValue = criticalValue;
        this.criticalChance = criticalChance;
    }

    public Item(float id, float damage)
    {
        this.ID = id;
        this.damage = damage;
        this.speed = 1;
        this.range = 1;
        this.criticalValue = 0;
        this.criticalChance = 0;
    }

    public Item()
    {
        this.ID = -1;
    }
}
public class Character
{
    public float ID { get; set; }
    public float hp { get; set; }
    public float acc { get; set; }
    public float strenght { get; set; }
    public float power { get; set; }
    public float criticalChance { get; set; }
    public float agility { get; set; }
    public float shield { get; set; }
    public string name { get; set; }
    public Item gun { get; set; }

    public Character(float id, float hp, float acc, float strenght, float power, float critical, float agility, float shield,string name)
    {
        this.ID = id;
        this.hp = hp;
        this.acc = acc;
        this.strenght = strenght;
        this.power = power;
        this.criticalChance = critical;
        this.agility = agility;
        this.shield = shield;
        this.name = name;
    }

    public Character(float id, float hp)
    {
        this.ID = id;
        this.hp = hp;
    }

    public Character()
    {
        this.ID = -1;
    }
}
