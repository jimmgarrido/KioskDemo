#!/bin/sh

PROJECT_NAME="MOVAI"
DESKTOP_PATH="$HOME/Desktop"
PROJECT_PATH="$DESKTOP_PATH/$PROJECT_NAME"

pkill Visual Studio

cd $PROJECT_PATH

if [ "$1" = "archive" ]; then
    echo "Cleaning bin/ and obj/ directories..."
    find . -maxdepth 2 \( -name bin -o -name obj -o -name .vs \) -type d -exec rm -r {} +
    
    echo "Zipping project to desktop..."
    zip -r $PROJECT_NAME.zip .
    mv $PROJECT_NAME.zip $DESKTOP_PATH
fi

echo "Deleting project files..."
rm -r $PROJECT_PATH

if [ "$1" = "reset" ]; then
    rm $PROJECT_PATH.zip
fi
echo "Clean up complete!"