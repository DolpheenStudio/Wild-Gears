using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerUnitTests
{
    bool sceneLoaded;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneLoaded = true;
    }

    [UnityTest]
    public IEnumerator PlayerLevelUpTest()
    {
        yield return new WaitWhile(() => sceneLoaded == false);

        var player = Object.FindObjectOfType<Player>();
        int _playerLevel = player.playerLevel;

        player.LevelUp();

        Assert.AreEqual(_playerLevel + 1, player.playerLevel);
    }

    [UnityTest]
    public IEnumerator PlayerHealTest()
    {
        yield return new WaitWhile(() => sceneLoaded == false);

        var player = Object.FindObjectOfType<Player>();
        player.playerHealth = 1;

        player.HealPlayer(20);

        Assert.AreEqual(21, player.playerHealth);
    }

    [UnityTest]
    public IEnumerator PlayerDamageTest()
    {
        yield return new WaitWhile(() => sceneLoaded == false);

        var player = Object.FindObjectOfType<Player>();
        player.playerHealth = 100;

        player.DealDamage(20);

        Assert.AreEqual(80, player.playerHealth);
    }
}
