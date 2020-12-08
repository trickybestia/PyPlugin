# PRIORITY 100

from Exiled.API.Features.Log import Send
from System import ConsoleColor
from Discord import LogLevel

def debug(message):
	Send("[" + str(NAME) + "] " + str(message), LogLevel.Debug, ConsoleColor.Green)
def info(message):
	Send("[" + str(NAME) + "] " + str(message), LogLevel.Info, ConsoleColor.Cyan)
def warn(message):
	Send("[" + str(NAME) + "] " + str(message), LogLevel.Warn, ConsoleColor.Magenta)
def error(message):
	Send("[" + str(NAME) + "] " + str(message), LogLevel.Error, ConsoleColor.DarkRed)