#!/bin/bash

docker build -t filebrowser .

docker run --detach --rm --publish 8080:80 -v /home/albert:/app/wwwroot/files --name filebrowser filebrowser
