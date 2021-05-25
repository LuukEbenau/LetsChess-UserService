docker build . -t sacation/letschess-userservice
docker push sacation/letschess-userservice
kubectl delete pods -l letschess.service=userservice -n letschess