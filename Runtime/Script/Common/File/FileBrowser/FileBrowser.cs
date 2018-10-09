//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BlackFire.Unity
{
	public class FileBrowser : MonoBehaviour, IPointerDownHandler, IPointerClickHandler
	{
		public System.Func<byte[], IEnumerator> fileHandler;

#if UNITY_WEBGL
		[DllImport("__Internal")]
		private static extern void fileBrowserInit(string objectName, string callbackFuncName);

		[DllImport("__Internal")]
		private static extern void fileBrowserSetFocus();
#endif

		void Start()
		{
#if UNITY_WEBGL
			fileBrowserInit(gameObject.name, "FileDialogResult");
#endif
		}

		public void OnPointerDown(PointerEventData eventData)
		{
#if UNITY_WEBGL
			if (button != null && !button.interactable)
				return;
			fileBrowserSetFocus();
#endif
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			StartCoroutine(OpenFile());
		}

		private static void DisplayWarning (string title, string msg)
		{
			//Debug.LogFormat ("{0}: {1}", title, msg);
#if UNITY_EDITOR
			EditorUtility.DisplayDialog (title, msg, "Ok");
#endif
		}

		private string m_DisplayDialogTitle = "Select .jpg or .png selfie photo";
		public string DisplayDialogTitle
		{
			get { return m_DisplayDialogTitle; }
			set { m_DisplayDialogTitle = value; }
		}
		
		private string m_DisplayDialogMsg = "Please select frontal photo of a person in .jpg or .png format. Works best on smartphone selfies (iPhone, Samsung, etc.)";
		public string DisplayDialogMsg
		{
			get { return m_DisplayDialogMsg; }
			set { m_DisplayDialogMsg = value; }
		}
		
		private string m_OpenFileTitle = "Select .jpg selfie photo";
		public string OpenFileTitle
		{
			get { return m_OpenFileTitle; }
			set { m_OpenFileTitle = value; }
		}

		private string[] m_OpenFileFilters = new string[] {
			"Selfie",
			"jpg,jpeg,png"
		};
		public string[] OpenFileFilters
		{
			get { return m_OpenFileFilters; }
			set { m_OpenFileFilters = value; }
		}
		
		private IEnumerator OpenFile()
		{
			string photoPath = string.Empty;
#if UNITY_EDITOR
			DisplayWarning(
				m_DisplayDialogTitle,
				m_DisplayDialogMsg
			);
			photoPath = EditorUtility.OpenFilePanelWithFilters(m_OpenFileTitle, "", m_OpenFileFilters);

			photoPath = Utility.Win32.OpenFileDialogWin32(m_OpenFileTitle);

#elif UNITY_STANDALONE_WIN

#elif UNITY_ANDROID
//			AndroidImageSupplier imageSupplier = new AndroidImageSupplier();
//			yield return imageSupplier.GetImageFromStorageAsync();
//			photoPath = imageSupplier.FilePath;
#elif UNITY_IOS
//			IOSImageSupplier imageSupplier = IOSImageSupplier.Create();
//			yield return imageSupplier.GetImageFromStorageAsync();
//			photoPath = imageSupplier.FilePath;
#endif
			if (string.IsNullOrEmpty(photoPath))
				yield break;
			byte[] bytes = File.ReadAllBytes(photoPath);
			if (fileHandler != null)
				yield return fileHandler(bytes);
		}

		private void FileDialogResult(string fileUrl)
		{
			//Debug.Log(fileUrl);
			StartCoroutine(LoadFile(fileUrl));
		}

		private IEnumerator LoadFile(string url)
		{
			var www = new WWW(url);
			yield return www;
			if (fileHandler != null)
				StartCoroutine(fileHandler(www.bytes));
		}
	}
}