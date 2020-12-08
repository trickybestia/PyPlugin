# PRIORITY 0

from Exiled.Events import Handlers as handlers
from MEC import Timing
from UnityEngine import Application
from Exiled.API.Features import Player

NAME = "PyPlugin.Example"
AUTHOR = "TrickyBestia"
VERSION = "1.0.0.0"

coroutine = 0

def messagesBroadcasterCoroutine():
    i = 0
    while i < Application.targetFrameRate * MESSAGE_ROUND_START_DELAY:
        i += 1
        yield Timing.WaitForOneFrame
    while True:
        for player in Player.List:
            player.Broadcast(MESSAGE_DURATION, MESSAGE)
        i = 0
        while i < Application.targetFrameRate * MESSAGE_COOLDOWN:
            i += 1
            yield Timing.WaitForOneFrame

def onRoundStarted():
    coroutine = Timing.RunCoroutine(
        toCoroutine(messagesBroadcasterCoroutine()))

def onRestartingRound():
    Timing.KillCoroutines(coroutine)

def onEnabled():
    info("Hello! I am " + NAME + " and I was enabled!")
    handlers.Server.RoundStarted += onRoundStarted
    handlers.Server.RestartingRound += onRestartingRound