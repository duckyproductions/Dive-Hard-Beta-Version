using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{

	public Slider slider;


	// Update is called once per frame
	void Update()
	{

	}

	public IEnumerator WaitToLoad(string escena)
	{
		AsyncOperation async = SceneManager.LoadSceneAsync(escena);
		while (!async.isDone)
		{
			float progress = Mathf.Clamp01(async.progress);
            slider.value = Mathf.MoveTowards(slider.value,progress,Time.deltaTime);
			yield return null;
		}
	}
}
