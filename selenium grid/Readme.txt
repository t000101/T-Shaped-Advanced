
--------------------------Condition to run parallel-------------------------
 Precondition
 - Download java jdk 8
 - Chrome version: 102

1.
start hub: java -jar selenium-server-standalone-3.141.59.jar -role hub

2.
start node: java -Dwebdriver.chrome.driver="chromedriver.exe" -jar selenium-server-standalone-3.141.59.jar -role node -nodeConfig config.json

