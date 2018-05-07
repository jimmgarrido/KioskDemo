#!/bin/sh
PROJECT_NAME="MOVAI"
PROJECT_PATH="$HOME/Build2018/$PROJECT_NAME"
DESKTOP_PATH="$HOME/Desktop/"

echo "Copying project to desktop"
cp -R $PROJECT_PATH $DESKTOP_PATH

echo "Opening solution..."
# open -g $DESKTOP_PATH/$PROJECT_NAME/$PROJECT_NAME.sln -a "Visual Studio.app"