#!/bin/sh

BUILD_PROJECT="$HOME/Build2018/Project/"
DESKTOP_PATH="$HOME/Desktop/"

echo "Copying project to desktop"
cp -R $BUILD_PROJECT/* $DESKTOP_PATH

echo "Opening solution..."
open $DESKTOP_PATH/Testing/Testing.sln -a "Visual Studio.app"