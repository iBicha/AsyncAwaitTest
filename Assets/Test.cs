using System.Threading.Tasks;
using UnityEngine;

public class Test : MonoBehaviour {

	private async void Start()
	{
		for (int i = 0; i < 5; i++)
		{
			Debug.Log(Time.frameCount);
			//A call to EmptyTask() should last at least 1 frame, according to how the SynchronizationContext should work
			//But the first call returns immediately, which means it was run in a synchronous manner
			await EmptyTask();
		}
		
		/*
		 * Expected output:
		 * 1
		 * 2
		 * 3
		 * 4
		 * 5
		 *
		 *
		 *
		 * Actual output:
		 * 1
		 * 1
		 * 2
		 * 3
		 * 4
		 */

	}

	async Task EmptyTask()
	{
		await Task.Run(() => { });
	}
}
