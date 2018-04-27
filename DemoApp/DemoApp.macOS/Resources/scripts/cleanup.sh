#!/bin/sh

PROJECT_NAME="Testing"
DESKTOP_PATH="$HOME/Desktop"
PROJECT_PATH="$DESKTOP_PATH/$PROJECT_NAME"

pkill Visual Studio

cd $PROJECT_PATH

echo $1
echo "Cleaning bin/ and obj/ directories..."
find . -maxdepth 2 \( -name bin -o -name obj -o -name .vs \) -type d -exec rm -r {} +

if [ "$1" = "archive" ]; then
    echo "Zipping project to desktop..."
    zip -r $PROJECT_NAME.zip .
    mv $PROJECT_NAME.zip $DESKTOP_PATH
fi

rm -r $PROJECT_PATH