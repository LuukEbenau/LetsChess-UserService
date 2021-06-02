@ECHO OFF
ECHO Lets update the service!
cd ../
docker build -t sacation/letschess-userservice  . -f LetsChess-MatchmakingService/Dockerfile
docker push sacation/letschess-userservice