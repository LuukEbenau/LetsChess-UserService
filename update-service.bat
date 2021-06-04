@ECHO OFF
ECHO Lets update the service!

docker build -t sacation/letschess-userservice  .
docker push sacation/letschess-userservice