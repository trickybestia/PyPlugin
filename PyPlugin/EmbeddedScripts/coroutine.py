# PRIORITY 100

from PyPlugin.EmbeddedScriptsApi.Coroutine import ToIEnumerator
from System import Single

def toCoroutine(generator):
	return ToIEnumerator[Single](generator)