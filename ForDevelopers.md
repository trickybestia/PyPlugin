# For developers

Hello developer!
If you want to write SCP: SL plugins with EXILED and Python it is very simple!

## Creating files

For start you should create folder (preferably with your plugin's name).
Then you should create plugin.py and config.py in this folder.
Now you can write some code!

## Writing some code
### First steps

For example, you want to greet every player connected to the server.
Open plugin.py and write
```Python
    NAME = "PlayerGreeter"
    VERSION = "1.0.0.0"
    AUTHOR = "Your name"
```
Copy plugin's folder in your Python plugins folder and start server. You will see that message:
```
[17:06:00] [INFO] [PyPlugin] PlayerGreeter v1.0.0, made by Your name, has been enabled!
```

### Registering event handlers

So you need to send broadcast to player when he is connected to your server. You need to register an event handler which will be called by server when player connects.
```Python
    from Eiled.Events import Handlers as handlers

    NAME = "PlayerGreeter"
    AUTHOR = "Your name"
    VERSION = "1.0.0.0"

    def onPlayerJoined(args):
        args.Player.Broadcast(10, "Greetings, player!")

    def onEnabled():
        handlers.Player.Joined += onPlayerJoined
```

### Creating config

So you have written your plugin with 1000 (11, I counted lol) lines of code and you want to publish it.
But plugin users can be a little stupid so they can't edit your code to change some values they want.
It is time for the config.py! Open it and write that:
```Python
    # PRIORITY 100
    # Later about priorities

    BROADCAST_MESSAGE = "Greetings, player!" # You MUST (no) use upper letters because it is more glamorous than lower (yes)
    BROADCAST_DURATION = 10
```
Now you can change your plugin.py:
```Python
    from Eiled.Events import Handlers as handlers

    NAME = "PlayerGreeter"
    AUTHOR = "Your name"
    VERSION = "1.0.0.0"

    def onPlayerJoined(args):
        args.Player.Broadcast(BROADCAST_DURATION, BROADCAST_MESSAGE)

    def onEnabled():
        handlers.Player.Joined += onPlayerJoined
```

### Priorities

Priority definition:
```Python
# PRIORITY 100
```
Files with higher priorities are being loaded earlier.

# You can find another example [here](https://github.com/TrickyBestia/PyPlugin/tree/master/PyPlugin.Example)