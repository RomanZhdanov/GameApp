import clr
clr.AddReference("GameApp.Application")
from GameApp.Application.Common.Interfaces import IHowLongToBeatService

class HowLongToBeat(IHowLongToBeatService):
    def GetGame(self, gameName):
        return "Found a game with IronPython: " + gameName;