using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class EnemyUnitTests
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
    public IEnumerator EnemyDamageTest()
    {
        yield return new WaitWhile(() => sceneLoaded == false);

        var enemy = Object.FindObjectOfType<Enemy>();
        enemy.enemyHealth = 100;

        enemy.DealDamageToEnemy(10, Vector3.zero);

        Assert.AreEqual(90, enemy.enemyHealth);
    }

    [UnityTest]
    public IEnumerator EnemyDestroyTest()
    {
        yield return new WaitWhile(() => sceneLoaded == false);

        var enemy = Object.FindObjectOfType<Enemy>();

        enemy.DestroyEnemy();

        yield return null;

        if(enemy == null)
        {
            Assert.AreEqual(1, 1);
        }
        else
        {
            Assert.AreEqual(null, enemy);
        }
    }
}
