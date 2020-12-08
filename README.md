# PyPlugin

![Main CI](https://github.com/TrickyBestia/PyPlugin/workflows/Main%20CI/badge.svg)
![Release](https://img.shields.io/github/v/release/TrickyBestia/PyPlugin.svg?include_prereleases&style=flat)
![Total Downloads](https://img.shields.io/github/downloads/TrickyBestia/EXILED/PyPlugin.svg?style=flat)

PyPlugin is an [EXILED](https://github.com/galaxy119/EXILED) plugin, which allows you to write plugins in Python. You can use all Exiled API in your plugin (except yaml configs).

# Installation

You should download binaries from [releases page](https://github.com/TrickyBestia/PyPlugin/releases), unarchive them and put them in plugins folder (%appdata%/EXILED/Plugins for Windows).

Then you should download plugins and put them into folder you specified in PyPlugin's config.
It will look like:
```
Python:
    PluginA:
        plugin.py
        config.py
    PluginB:
        plugin.py
        config.py
```

# Config

Python plugins don't have yaml configs, but developer can create config.py file in plugin's folder with ~same content:
```python
# PRIORITY 100

# Broadcast duration
MESSAGE_DURATION = 10
# Broadcast message
MESSAGE = "Hello, I am test plugin!"
# Time between broadcasts
MESSAGE_COOLDOWN = 30
# Delay before first broadcast
MESSAGE_ROUND_START_DELAY = 10
```
And you can edit values in this file.

# [For developers](https://github.com/TrickyBestia/PyPlugin/blob/development/ForDevelopers.md)