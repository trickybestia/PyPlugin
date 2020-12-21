# PRIORITY 0

from Exiled.Events import Handlers as handlers
from MEC import Timing
from UnityEngine import Application
from Exiled.API.Features import Player

coroutine = 0

def messagesBroadcasterCoroutine():
    for i in range(Application.targetFrameRate * MESSAGE_ROUND_START_DELAY):
            yield Timing.WaitForOneFrame
    while True:
        for player in Player.List:
            player.Broadcast(MESSAGE_DURATION, MESSAGE)
        for i in range(Application.targetFrameRate * MESSAGE_COOLDOWN):
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