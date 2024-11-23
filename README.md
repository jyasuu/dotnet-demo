# dotnet-demo

```sh
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
export DOTNET_ROOT=$HOME/.dotnet
export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools
bash dotnet-install.sh -c 8.0
bash dotnet-install.sh -c 9.0
dotnet --list-sdks
dotnet tool install --global dotnet-ef

dotnet new console -n DemoCli

dotnet new webapi -n ChatApi
dotnet add package Microsoft.Extensions.Http


curl -X POST "http://localhost:5036/api/chatcompletion" -H "Content-Type: application/json" -d '{
  "messages": [
    { "role": "system", "content": "You are a test assistant." },
    { "role": "user", "content": "Testing. Just say hi and hello world and nothing else." }
  ],
  "model": "grok-beta",
  "stream": false,
  "temperature": 0
}'


```