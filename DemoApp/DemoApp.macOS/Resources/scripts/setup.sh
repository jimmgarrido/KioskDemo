#!/bin/sh

DESKTOP_PATH="$HOME/Desktop/"

echo "Copying project to desktop"
unzip Testing.zip -d $DESKTOP_PATH

echo "Opening solution..."
open -g $DESKTOP_PATH/Testing/Testing.sln -a "Visual Studio.app"