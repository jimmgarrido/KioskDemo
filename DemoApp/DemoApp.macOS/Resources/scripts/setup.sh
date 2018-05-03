#!/bin/sh
PROJECT_NAME="MOVAI"
DESKTOP_PATH="$HOME/Desktop/"

echo "Copying project to desktop"
unzip $PROJECT_NAME.zip -d $DESKTOP_PATH

echo "Opening solution..."
open -g $DESKTOP_PATH/$PROJECT_NAME/$PROJECT_NAME.sln -a "Visual Studio.app"