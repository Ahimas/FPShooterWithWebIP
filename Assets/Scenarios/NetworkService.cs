using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkService {
	private const string jsonApi = "http://api.openweathermap.org/data/2.5/weather?q=Naples,it&appid=9aed72c58970d65e435843ffc18a6097";
	private const string webImage = "http://upload.wikimedia.org/wikipedia/commons/c/c5/Moraine_Lake_17092005.jpg";

	private IEnumerator CallAPI(string url, Action<string> callback) {
		using ( UnityWebRequest request = UnityWebRequest.Get(url) ) {
			
			yield return request.Send();
			
			if ( request.isNetworkError ) {
				Debug.Log("Network problem: " + request.responseCode);
			} else if ( request.responseCode != (long)System.Net.HttpStatusCode.OK) {
				Debug.Log("Network problem: " + request.responseCode);
			} else {
				callback(request.downloadHandler.text);
			}
				
		}
				
	}
	
	public IEnumerator GetWeatherJSON(Action<string> callback) {
		return CallAPI(jsonApi, callback);
		
	}
	
	public IEnumerator DownloadImage(Action<Texture2D> callback) {
		UnityWebRequest request = UnityWebRequestTexture.GetTexture(webImage);
		
		yield return request.Send();
		
		callback(DownloadHandlerTexture.GetContent(request));
	}			

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
